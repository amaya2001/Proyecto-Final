using Microsoft.AspNetCore.Mvc;
using ProyectoSemestral.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoSemestral.Controllers
{
    public class AccesoController : Controller
    {
            
        public IActionResult Login()
        {
            return View();
        }
        static string cadena = "Data Source = DESKTOP-AT13GP0\\MSSQLSERVER_1; initial Catalog = DBPROYECTO; Integrated Security = true";
        public static string ConvertirClave(string txt)
        {
            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(txt));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

        [HttpPost]
        public IActionResult Login(Administrador oAdministrador)
        {
            oAdministrador.Clave = ConvertirClave(oAdministrador.Clave);
            bool rpta;
            try
            {
                
                using (SqlConnection cn = new SqlConnection(cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                    if (oAdministrador.Correo.All(char.IsLetterOrDigit))
                    {
                        cmd.Parameters.AddWithValue("Correo", oAdministrador.Correo);
                    }
                    else
                    {
                        ViewData["Mensaje"] = "Solo caracteres alfanumericos";
                        return View();
                    }
                    cmd.Parameters.AddWithValue("Clave", oAdministrador.Clave);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    oAdministrador.IdAdministrador = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                }
                rpta = false;
                if (oAdministrador.IdAdministrador != 0)
                {

                    return RedirectToAction("Menu", "Mantenedor");
                }
                else
                {
                    ViewData["Mensaje"] = "Usuario no encontrado";
                    return View();
                }
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return View();
        }
    }
}
