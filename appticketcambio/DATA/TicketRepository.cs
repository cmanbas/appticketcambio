using System;
using System.Data.SqlClient;
 

public static class TicketRepository
{
    public static   string _connectionString;

  
    public class TicketModel
    {
        public string transferid { get; set; }
        public string nroboleta { get; set; }
        public DateTime fechaboleta { get; set; }
        public string sfechaboleta { get; set; }
        public int qty { get; set; }
        public int linenum { get; set; }
        public string itemid { get; set; }
        public int cantidad { get; set; }
        public string barcode { get; set; }
        public DateTime fechaoms { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public DateTime fechasignacion { get; set; }
        public DateTime fechaimpresion { get; set; }
        public string manifiesto { get; set; }
        public string fechamanifiesto { get; set; }
        public string courier { get; set; }
    }

    public static void InsertTicket(TicketModel ticket)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand("sp_insert_ticket", conn, transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@transferid", ticket.transferid);
                cmd.Parameters.AddWithValue("@nroboleta", ticket.nroboleta);
                cmd.Parameters.AddWithValue("@fechaboleta", ticket.fechaboleta);
                cmd.Parameters.AddWithValue("@sfechaboleta", ticket.sfechaboleta);
                cmd.Parameters.AddWithValue("@qty", ticket.qty);
                cmd.Parameters.AddWithValue("@linenum", ticket.linenum);
                cmd.Parameters.AddWithValue("@itemid", ticket.itemid);
                cmd.Parameters.AddWithValue("@cantidad", ticket.cantidad);
                cmd.Parameters.AddWithValue("@barcode", ticket.barcode);
                cmd.Parameters.AddWithValue("@fechaoms", ticket.fechaoms);
                cmd.Parameters.AddWithValue("@idusuario", ticket.idusuario);
                cmd.Parameters.AddWithValue("@usuario", ticket.usuario);
                cmd.Parameters.AddWithValue("@fechasignacion", ticket.fechasignacion);
                cmd.Parameters.AddWithValue("@manifiesto", ticket.manifiesto);
                cmd.Parameters.AddWithValue("@fechamanifiesto", ticket.fechamanifiesto);
                cmd.Parameters.AddWithValue("@courier", ticket.courier);

                // Ejecutar el comando dentro de la transacción
                cmd.ExecuteNonQuery();

                // Confirmar la transacción
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // En caso de error, deshacer la transacción
                transaction.Rollback();
                throw new Exception("Error al insertar el ticket: " + ex.Message);
            }
        }
    }

    public static void InsertTicketFirst(TicketModel ticket)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                SqlCommand cmd = new SqlCommand("[sp_insert_ticketv02]", conn, transaction);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Transaction = transaction;
                cmd.Parameters.AddWithValue("@transferid", ticket.transferid);
                cmd.Parameters.AddWithValue("@nroboleta", ticket.nroboleta);
                cmd.Parameters.AddWithValue("@fechaboleta", ticket.fechaboleta);
                cmd.Parameters.AddWithValue("@sfechaboleta", ticket.sfechaboleta);
                cmd.Parameters.AddWithValue("@qty", ticket.qty);
                cmd.Parameters.AddWithValue("@linenum", ticket.linenum);
                cmd.Parameters.AddWithValue("@itemid", ticket.itemid);
                cmd.Parameters.AddWithValue("@cantidad", ticket.cantidad);
                cmd.Parameters.AddWithValue("@barcode", ticket.barcode);
                 cmd.Parameters.AddWithValue("@idusuario", ticket.idusuario);
                 cmd.Parameters.AddWithValue("@usuario", ticket.usuario);
                //cmd.Parameters.AddWithValue("@fechaimpresion", ticket.fechaimpresion);
 

                // Ejecutar el comando dentro de la transacción
                var filas = cmd.ExecuteNonQuery();

                // Confirmar la transacción
                transaction.Commit();
            }
            catch (Exception ex)
            {
                // En caso de error, deshacer la transacción
                transaction.Rollback();
                throw new Exception("Error al insertar el ticket: " + ex.Message);
            }
        }
    }
}
