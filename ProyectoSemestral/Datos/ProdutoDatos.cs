using ProyectoSemestral.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace ProyectoSemestral.Datos
{
    public class ProdutoDatos
    {
        static string cadena = "Data Source = DESKTOP-AT13GP0\\MSSQLSERVER_1; initial Catalog = DBPROYECTO; Integrated Security = true";
        public bool AgregarDispositivos(Dispositivo odispositivo)
        {
            bool rpta;
            try
            {
                var oDispositivo = new Dispositivo();
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarDispositivo", cn);
                    cmd.Parameters.AddWithValue("Nombre", odispositivo.Nombre);
                    cmd.Parameters.AddWithValue("Tipo", odispositivo.Tipo);
                    cmd.Parameters.AddWithValue("Descripcion", odispositivo.Descripcion);
                    cmd.Parameters.AddWithValue("Imagen", odispositivo.Imagen);
                 
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

        public List<Dispositivo> Listar()
        {
            var oLista = new List<Dispositivo>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarDispositivo", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Dispositivo()
                        {
                            Id = Convert.ToInt32(dr["IdDispositivo"]),
                            Nombre = Convert.ToString(dr["Nombre"]),
                            Tipo = Convert.ToString(dr["Tipo"]),
                            Descripcion = Convert.ToString(dr["Descripcion"]),
                            Imagen = Convert.ToString(dr["Imagen"]),
                        });
                    }
                }
            }
            return oLista;
        }
    }
}
