using System;
using System.Collections.Generic;
using System.Text;

namespace appticketcambio.Dto
{
    public class ProductoDTO
    {
        public string boleta { get; set; }
        public string cliente { get; set; }
        public string fecha { get; set; }
        public string pedido { get; set; }

    }
    public class BoletaDTO
    {
        // ax generacion de carga de trabajo , liberar 
        // pistolita a relacion usuario pedido. ( despues de impresa )
     
        public string transferid { get; set; }
        public string nroboleta { get; set; }
        public DateTime fechaboleta { get; set; }
        public string sfechaboleta { get; set; }
        public Double qty { get; set; }
        public Double linenum { get; set; }
        public string itemid { get; set; }
        public Double cantidad { get; set; }
        public string barcode { get; set; }
        public DateTime fechaimpresion { get; set; }

        public DateTime fechaoms { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public DateTime fechasignacion { get; set; }
        public string manifiesto { get; set; }
        public string fechamanifiesto { get; set; }
        
        public string courier { get; set; }
    }
    public class ErrorSP
    {
        public string NumError { get; set; }
        public string MensajeError { get; set; }
        public int Id { get; set; }
        public int IdTienda { get; set; }
        public int Nombre { get; set; }
        public int filas { get; set; }
    }
}
