using System.ComponentModel.DataAnnotations;

namespace API_Agenda.Model
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        public required string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [Phone(ErrorMessage = "El número de teléfono no es válido")]
        public required string Telefono { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public Usuario() { }

        public Usuario(int id, string nombre, string correo, string telefono)
        {
            Id = id;
            Nombre = nombre;
            Correo = correo;
            Telefono = telefono;
            FechaRegistro = DateTime.Now;
        }

    }
}
