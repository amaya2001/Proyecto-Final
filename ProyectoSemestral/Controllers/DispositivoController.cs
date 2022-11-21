using Microsoft.AspNetCore.Mvc;
using ProyectoSemestral.Datos;
using ProyectoSemestral.Models;


namespace ProyectoSemestral.Controllers
{
    public class DispositivoController : Controller
    {
        ProdutoDatos _Dispositivo = new ProdutoDatos();
        public IActionResult Listar()
        {
            var oLista = _Dispositivo.Listar();
            // Metodo solo devuelve la vista
            return View(oLista);
        }
        public IActionResult AgregarDispositivos()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AgregarDispositivos(Dispositivo oDispositivo)
        {
            if (!ModelState.IsValid)
                return View();

            var respuesta = _Dispositivo.AgregarDispositivos(oDispositivo);
            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
