namespace ProyectoSemestral.Models
{
    public class Reservas
    {
        public int IdReserva { get; set; }
        public string? Nombre { get; set; }
        public int Documento { get; set; }
        public DateTime? FechaHora { get; set; }
        public string? Duracion { get; set; }
        public string? Lugar { get; set; }
        public string? TipoDispositivo { get; set; }
    }
}
