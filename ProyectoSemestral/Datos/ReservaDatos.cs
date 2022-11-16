using ProyectoSemestral.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoSemestral.Datos
{
    public class ReservaDatos
    {
        static string cadena = "Data Source = DESKTOP-AT13GP0\\MSSQLSERVER_1; initial Catalog = DBPROYECTO; Integrated Security = true";
        public List<Reservas> Listar()
        {
            var oLista = new List<Reservas>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Reservas()
                        {
                            IdReserva = Convert.ToInt32(dr["IdReserva"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Documento = Convert.ToInt32(dr["Documento"]),
                            FechaHora = Convert.ToDateTime(dr["FechaHora"]),
                            Duracion = Convert.ToString(dr["Duracion"]),
                            Lugar = Convert.ToString(dr["Lugar"]),
                            TipoDispositivo = Convert.ToString(dr["TipoDispositivo"])
                        });
                    }
                }
            }
            return oLista;
        }

        public Reservas Obtener(int IdReserva)
        {
            var oReserva = new Reservas();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", cn);
                cmd.Parameters.AddWithValue("IdReserva", IdReserva);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oReserva.IdReserva = Convert.ToInt32(dr["IdReserva"]);
                        oReserva.Nombre = Convert.ToString(dr["Nombre"]);
                        oReserva.Documento = Convert.ToInt32(dr["Documentacion"]);
                        oReserva.FechaHora = Convert.ToDateTime(dr["FechaHora"]);
                        oReserva.Duracion = Convert.ToString(dr["Duracion"]);
                        oReserva.Lugar = Convert.ToString(dr["Lugar"]);
                        oReserva.TipoDispositivo = Convert.ToString(dr["TipoDispositivo"]);
                    }
                }
            }
            return oReserva;
        }

        public bool Guardar(Reservas oreservas)
        {
            bool rpta;
            try
            {
                var oReserva = new Reservas();
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar1", cn);
                    cmd.Parameters.AddWithValue("Nombre", oreservas.Nombre);
                    cmd.Parameters.AddWithValue("Documento", oreservas.Documento);
                    cmd.Parameters.AddWithValue("FechaHora", oreservas.FechaHora);
                    cmd.Parameters.AddWithValue("Duracion", oreservas.Duracion);
                    cmd.Parameters.AddWithValue("Lugar", oreservas.Lugar);
                    cmd.Parameters.AddWithValue("TipoDispositivo", oreservas.TipoDispositivo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdReserva)
        {
            bool rpta;
            try
            {
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", cn);
                    cmd.Parameters.AddWithValue("IdReserva", IdReserva);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
