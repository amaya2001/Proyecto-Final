using Microsoft.AspNetCore.Mvc;
using ProyectoSemestral.Models;
using System.Data.SqlClient;
using System.Data;

namespace ProyectoSemestral.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        static string cadena = "Data Source = DESKTOP-AT13GP0\\MSSQLSERVER_1; initial Catalog = DBPROYECTO; Integrated Security = true";

        [HttpPost]
        public IActionResult Login(Administrador oAdministrador)
        {
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Correo", oAdministrador.Correo);
                cmd.Parameters.AddWithValue("Clave", oAdministrador.Clave);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                oAdministrador.IdAdministrador = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
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
    }
}
