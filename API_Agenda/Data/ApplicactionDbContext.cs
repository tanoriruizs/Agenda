using Agenda.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace API_Agenda.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var random = new Random();

            modelBuilder.Entity<Usuario>().HasData(
                AsignarEstado(new Usuario { Id = 1, Nombre = "Juan Pérez", Correo = "juan.perez@example.com", Telefono = "1234567890", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 2, Nombre = "María García", Correo = "maria.garcia@example.com", Telefono = "0987654321", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 3, Nombre = "Carlos López", Correo = "carlos.lopez@example.com", Telefono = "5555555555", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 4, Nombre = "Ana Martínez", Correo = "ana.martinez@example.com", Telefono = "1111111111", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 5, Nombre = "Luis Rodríguez", Correo = "luis.rodriguez@example.com", Telefono = "2222222222", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 6, Nombre = "Sofía Hernández", Correo = "sofia.hernandez@example.com", Telefono = "3333333333", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 7, Nombre = "Pedro Díaz", Correo = "pedro.diaz@example.com", Telefono = "4444444444", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 8, Nombre = "Lucía Sánchez", Correo = "lucia.sanchez@example.com", Telefono = "6666666666", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 9, Nombre = "Jorge Ramírez", Correo = "jorge.ramirez@example.com", Telefono = "7777777777", FechaRegistro = DateTime.Now }),
                AsignarEstado(new Usuario { Id = 10, Nombre = "Elena Torres", Correo = "elena.torres@example.com", Telefono = "8888888888", FechaRegistro = DateTime.Now })
            );
        }

        private Usuario AsignarEstado(Usuario usuario)
        {
            var random = new Random();
            int estado = random.Next(3);

            usuario.Favorito = estado == 1;
            usuario.ListaNegra = estado == 2;

            return usuario;
        }
    }
}
