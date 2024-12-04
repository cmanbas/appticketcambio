using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Printing;
using appticketcambio.Dto;
using System.Data.SqlClient;
using appticketcambio.DATA;

namespace appticketcambio
{
    public partial class Formetiqueta : Form
    {
        public string nombre;
        public string id;
        private readonly UserRepository _userRepository;
        private List<Usuarious> _users;
        public Formetiqueta()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
            LoadUsers();
        }
        private void LoadUsers()
        {
            try
            {
               var x_users = _userRepository.LoadUsers();

                cboUsers.DisplayMember = "NombreUsuario";
                cboUsers.ValueMember = "Id";

                cboUsers.Items.Add(new Usuarious { Id = 0, NombreUsuario = "Seleccione usuario" });
                cboUsers.Items.AddRange(x_users.ToArray());

                cboUsers.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            lbl_boleta.Text = "";
            lbl_cliente.Text = "";
            lbl_fecha.Text = "";
            lbl_pedido.Text = "";

            if (txt_pedido.Text.Trim() == "")
            {
                MessageBox.Show("Debe ingresar Pedido", "Error!!", MessageBoxButtons.OK); txt_pedido.Focus();
                return;
            }

            lbl_boleta.Text = "";
            lbl_cliente.Text = "";
            lbl_fecha.Text = "";
            lbl_pedido.Text = "";

            string basedatos = System.Configuration.ConfigurationManager.AppSettings["DatabaseServerProd"].ToString();// + System.Configuration.ConfigurationManager.AppSettings["SQLSERVER"];
            var varios = SP_busca_DocumentoAX(txt_pedido.Text.Trim(), basedatos);
            if (varios.Item1 == null)
            { MessageBox.Show("Problemas de Base de datos", "Error!", MessageBoxButtons.OK); txt_pedido.Text = ""; txt_pedido.Focus(); return; }
            if (varios.Item1.Count == 0)
            { MessageBox.Show("Pedido no existe", "Error!", MessageBoxButtons.OK); txt_pedido.Text = ""; txt_pedido.Focus(); return; }

            lbl_boleta.Text = varios.Item1[0].nroboleta;
            lbl_fecha.Text = varios.Item1[0].fechaboleta.ToString("dd-MM-yyyy");
            lbl_pedido.Text = varios.Item1[0].nroboleta;

            // Supongamos que tienes una lista de BoletaDTO llamada boletaList

            txt_zpl.Text = "";

            foreach (BoletaDTO boleta in varios.Item1)
            {
                // Almacena los valores en variables locales
                string transferId = boleta.transferid;
                string nroBoleta = boleta.nroboleta;
                DateTime fechaBoleta = boleta.fechaboleta;
                string sFechaBoleta = boleta.sfechaboleta;
                double qty = boleta.qty;
                double lineNum = boleta.linenum;
                string itemId = boleta.itemid;
                int cantidad = (int)Math.Ceiling(boleta.cantidad); // Redondeamos hacia arriba para asegurar que siempre imprimamos al menos una etiqueta
                string barcode = boleta.barcode;

                // Generamos e imprimimos la etiqueta tantas veces como indique la cantidad
                TicketRepository._connectionString = System.Configuration.ConfigurationManager.AppSettings["DatabaseServerProdCD"].ToString(); ;
                TicketRepository.TicketModel ticket = new TicketRepository.TicketModel();
                ticket.barcode = barcode;
                ticket.fechaboleta = fechaBoleta;
                ticket.nroboleta = nroBoleta;
                ticket.cantidad = cantidad;
                ticket.linenum = (int)lineNum;
                ticket.itemid = itemId;
                ticket.qty = (int)qty;
                ticket.usuario = cboUsers.Text;
                ticket.idusuario= ((DATA.Usuarious)cboUsers.SelectedItem).Id;
                ticket.transferid = transferId;
                ticket.sfechaboleta = sFechaBoleta;
                TicketRepository.InsertTicketFirst(ticket);

                for (int i = 0; i < cantidad; i++)
                {
                    txt_zpl.Text = "";
                    string zplCommand = @"^XA
                                        ^CI28
                                        ^CF0,30,45
                                        ^FO60,30 ^FDTICKET CAMBIO^FS
                                        ^CF0,17,17
                                        ^FO23,60 ^FDTienes hasta el 31 de enero de 2025 para el cambio^FS
                                        ^CF0,17,17
                                         ^FO60,90 ^FDFecha :" + fechaBoleta.ToString("dd-MM-yyyy") + "^FS" +
                                         @"^FO240,90 ^FDBoleta :" + nroBoleta + "^FS" +
                                         @"^BY2,2,40 ^BCN  
                                        ^FO16,117 ^FD" + barcode + "^FS ^XZ ";


                         PrintZPL(zplCommand);
                      




                   // Console.Write(zplCommand);
                              txt_zpl.Text =  "\r\n" + txt_zpl.Text + "\r\n" + zplCommand;

                }
            }

             

            txt_pedido.Text = ""; txt_pedido.Focus();

            string nombreimprespra = System.Configuration.ConfigurationManager.AppSettings["PrinterLAbel"].ToString();
 
        }
        private void PrintZPL(string zplCommand)
        {
            try
            {
                // Replace with your printer's name
                string printerName = System.Configuration.ConfigurationManager.AppSettings["PrinterLAbel"].ToString();

                // string printerName = "Qln220";
                RawPrinterHelper.SendStringToPrinter(printerName, zplCommand);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error printing label: " + ex.Message);
            }
        }
        public class RawPrinterHelper
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
            public class DOCINFOA
            {
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDocName;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pOutputFile;
                [MarshalAs(UnmanagedType.LPStr)]
                public string pDataType;
            }

            [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);

            [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool ClosePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

            [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndDocPrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool StartPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool EndPagePrinter(IntPtr hPrinter);

            [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
            public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

            public static bool SendStringToPrinter(string szPrinterName, string szString)
            {
                IntPtr pBytes;
                int dwCount = szString.Length;
                pBytes = Marshal.StringToCoTaskMemAnsi(szString);
                bool success = SendBytesToPrinter(szPrinterName, pBytes, dwCount);
                Marshal.FreeCoTaskMem(pBytes);
                return success;
            }

            public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, int dwCount)
            {
                IntPtr hPrinter;
                DOCINFOA di = new DOCINFOA();
                int dwWritten = 0;
                bool success = false;

                di.pDocName = "ZPL Document";
                di.pDataType = "RAW";

                if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
                {
                    if (StartDocPrinter(hPrinter, 1, di))
                    {
                        if (StartPagePrinter(hPrinter))
                        {
                            success = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                            EndPagePrinter(hPrinter);
                        }
                        EndDocPrinter(hPrinter);
                    }
                    ClosePrinter(hPrinter);
                }
                return success;
            }
        }
        public (List<BoletaDTO>, ErrorSP) SP_busca_DocumentoAX(string nroboleta, string conexion)
        {
            SqlConnection Conexion = new SqlConnection();
            ErrorSP respuesta = new ErrorSP();
            List<BoletaDTO> lista = new List<BoletaDTO>();

            try
            {
                Conexion.ConnectionString = conexion;



                respuesta.MensajeError = "ok";
                respuesta.NumError = "00";
                try
                {

                    SqlCommand comando = new SqlCommand(@"
                    SELECT [INVENTTRANSFERTABLE].[TRANSFERID]
                          ,[INVENTTRANSFERTABLE].DEAINVOICE NROBOLETA
                          ,[INVENTTRANSFERTABLE].[SHIPDATE] FECHABOLETA 
                          ,[QTY]
	                       ,LINENUM, 
	                        ITEMID, 
	                       QTYTRANSFER CANTIDAD, convert(CHAR(10), [INVENTTRANSFERTABLE].[SHIPDATE],105) SFECHA,
ISNULL( ( SELECT  top 1  ITEMBARCODE   FROM [ModellaAxProduccion].[dbo].[DFIINVENTITEMBARCODE] DI WHERE DI.ITEMID = InventTransferLine.ITEMID AND DI.[DATAAREAID] ='v-cv' ) ,'S/I') BARCODE
                      FROM  [INVENTTRANSFERTABLE] WITH (NOLOCK) ,InventTransferLine WITH (NOLOCK) 
                      WHERE [INVENTTRANSFERTABLE].[TRANSFERID] = '" + nroboleta + "' AND [INVENTTRANSFERTABLE].TRANSFERID =InventTransferLine.TRANSFERID  ORDER BY LINENUM "
                            , Conexion);
                    comando.CommandType = System.Data.CommandType.Text;




                    respuesta.Id = 0;
                    Conexion.Open();
                    comando.CommandTimeout = 240;
                    SqlDataReader dr = comando.ExecuteReader();
                    BoletaDTO dataunidad;
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            dataunidad = new BoletaDTO();
                            dataunidad.transferid = dr.GetValue(0).ToString();
                            dataunidad.nroboleta = dr.GetValue(1).ToString();
                            dataunidad.fechaboleta = DateTime.Parse(dr.GetValue(2).ToString());
                            dataunidad.qty = Double.Parse(dr.GetValue(3).ToString());
                            dataunidad.linenum = Double.Parse(dr.GetValue(4).ToString());
                            dataunidad.itemid = dr.GetValue(5).ToString();
                            dataunidad.cantidad = Double.Parse(dr.GetValue(6).ToString());
                            dataunidad.sfechaboleta = dr.GetValue(7).ToString();
                            dataunidad.barcode = dr.GetValue(8).ToString();
                            lista.Add(dataunidad);
 






                        }

                    }
                    else
                    {
                        respuesta.MensajeError = "Pedido no existe";
                        respuesta.NumError = "01";
                    }

                    Conexion.Close();



                    return (lista, respuesta);
                }
                catch (System.Data.SqlTypes.SqlTypeException pgMsg)
                {
                    respuesta.Id = -1;
                    respuesta.MensajeError = pgMsg.Message.ToString();
                    respuesta.NumError = "-1";
                    return (lista, respuesta);
                }
                catch (SqlException pgMsg)
                {
                    respuesta.Id = -1;
                    respuesta.MensajeError = pgMsg.Message.ToString();
                    respuesta.NumError = pgMsg.ErrorCode.ToString();
                    return (lista, respuesta);
                }
                finally
                {
                    if (Conexion.State == System.Data.ConnectionState.Open)
                    {
                        Conexion.Close();
                        Conexion.Dispose();
                        SqlConnection.ClearPool(Conexion);
                    }
                }


            }
            catch (SqlException pgMsg)
            {
                respuesta.Id = -1;
                respuesta.MensajeError = pgMsg.Message.ToString();
                respuesta.NumError = pgMsg.ErrorCode.ToString();
                return (lista, respuesta);
            }
        }

        private void txt_pedido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_buscar_Click(null, null);
            }
        }

        private void Formetiqueta_Load(object sender, EventArgs e)
        {

        }
    }
}
