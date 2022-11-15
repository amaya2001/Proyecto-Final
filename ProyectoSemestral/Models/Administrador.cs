using System.ComponentModel.DataAnnotations;

namespace ProyectoSemestral.Models
{
    public class Administrador
    { 
        public int IdAdministrador { get; set; }
        //[Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Correo { get; set; }
        //[Required(ErrorMessage = "El campo Clave es obligatorio")]
        public string? Clave { get; set; }
    }
}
