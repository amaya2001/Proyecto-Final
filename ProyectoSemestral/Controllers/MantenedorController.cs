using Microsoft.AspNetCore.Mvc;
using ProyectoSemestral.Datos;
using ProyectoSemestral.Models;

namespace ProyectoSemestral.Controllers
{
    public class MantenedorController : Controller
    {
        ReservaDatos _ReservaDatos = new ReservaDatos();
        public IActionResult Menu()
        {
            // Metodo solo devuelve la vista

            return View();
        }
        public IActionResult Reserva()
        {
            var oLista = _ReservaDatos.Listar();
            // Metodo solo devuelve la vista

            return View(oLista);
        }
        public IActionResult Guardar()
        {
            // Metodo solo devuelve la vista

            return View();
        }
        [HttpPost]
        public IActionResult Guardar(Reservas oReserva)
        {
            // Metodo recibe el objeto para guardarlo en BD
            if (!ModelState.IsValid)
                return View();

            var respuesta = _ReservaDatos.Guardar(oReserva);
            if (respuesta)
                return RedirectToAction("Reserva");
            else
                return View();
        }
        public IActionResult Eliminar(int IdReversa)
        {
            var oreserva = _ReservaDatos.Obtener(IdReversa);
            return View(oreserva);
        }


        [HttpPost]
        public IActionResult Eliminar(Reservas oReserva)
        {
            var rpt = _ReservaDatos.Eliminar(oReserva.IdReserva);
            if (rpt)
                return RedirectToAction("Reserva");
            else
                return View();
        }
        public IActionResult Bitacora()
        {
            // Metodo solo devuelve la vista

            return View();
        }
        public IActionResult Inventario()
        {
            // Metodo solo devuelve la vista

            return View();
        }
    }
}
