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

            // Seed data
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Juan Pérez", Correo = "juan.perez@example.com", Telefono = "1234567890", FechaRegistro = DateTime.Now },
                new Usuario { Id = 2, Nombre = "María García", Correo = "maria.garcia@example.com", Telefono = "0987654321", FechaRegistro = DateTime.Now },
                new Usuario { Id = 3, Nombre = "Carlos López", Correo = "carlos.lopez@example.com", Telefono = "5555555555", FechaRegistro = DateTime.Now },
                new Usuario { Id = 4, Nombre = "Ana Martínez", Correo = "ana.martinez@example.com", Telefono = "1111111111", FechaRegistro = DateTime.Now },
                new Usuario { Id = 5, Nombre = "Luis Rodríguez", Correo = "luis.rodriguez@example.com", Telefono = "2222222222", FechaRegistro = DateTime.Now },
                new Usuario { Id = 6, Nombre = "Sofía Hernández", Correo = "sofia.hernandez@example.com", Telefono = "3333333333", FechaRegistro = DateTime.Now },
                new Usuario { Id = 7, Nombre = "Pedro Díaz", Correo = "pedro.diaz@example.com", Telefono = "4444444444", FechaRegistro = DateTime.Now },
                new Usuario { Id = 8, Nombre = "Lucía Sánchez", Correo = "lucia.sanchez@example.com", Telefono = "6666666666", FechaRegistro = DateTime.Now },
                new Usuario { Id = 9, Nombre = "Jorge Ramírez", Correo = "jorge.ramirez@example.com", Telefono = "7777777777", FechaRegistro = DateTime.Now },
                new Usuario { Id = 10, Nombre = "Elena Torres", Correo = "elena.torres@example.com", Telefono = "8888888888", FechaRegistro = DateTime.Now },
                new Usuario { Id = 11, Nombre = "Gabriel Fernández", Correo = "gabriel.fernandez@example.com", Telefono = "9999999999", FechaRegistro = DateTime.Now },
                new Usuario { Id = 12, Nombre = "Natalia Ortega", Correo = "natalia.ortega@example.com", Telefono = "1010101010", FechaRegistro = DateTime.Now },
                new Usuario { Id = 13, Nombre = "Fernando Ruiz", Correo = "fernando.ruiz@example.com", Telefono = "1212121212", FechaRegistro = DateTime.Now },
                new Usuario { Id = 14, Nombre = "Paula Castro", Correo = "paula.castro@example.com", Telefono = "1313131313", FechaRegistro = DateTime.Now },
                new Usuario { Id = 15, Nombre = "Raúl Mendoza", Correo = "raul.mendoza@example.com", Telefono = "1414141414", FechaRegistro = DateTime.Now },
                new Usuario { Id = 16, Nombre = "Andrea Vega", Correo = "andrea.vega@example.com", Telefono = "1515151515", FechaRegistro = DateTime.Now },
                new Usuario { Id = 17, Nombre = "Santiago Guzmán", Correo = "santiago.guzman@example.com", Telefono = "1616161616", FechaRegistro = DateTime.Now },
                new Usuario { Id = 18, Nombre = "Valeria Navarro", Correo = "valeria.navarro@example.com", Telefono = "1717171717", FechaRegistro = DateTime.Now },
                new Usuario { Id = 19, Nombre = "Ricardo Soto", Correo = "ricardo.soto@example.com", Telefono = "1818181818", FechaRegistro = DateTime.Now },
                new Usuario { Id = 20, Nombre = "Isabel Romero", Correo = "isabel.romero@example.com", Telefono = "1919191919", FechaRegistro = DateTime.Now }
            );
        }
    }
}
