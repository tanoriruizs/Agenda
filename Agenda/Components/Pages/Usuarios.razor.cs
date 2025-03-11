﻿using Agenda.Shared.Model;

namespace Agenda.Components.Pages
{
    public partial class Usuarios
    {
        private List<Usuario>? usuarios;
        private Usuario usuarioSeleccionado = new Usuario();
        private bool mostrandoFormulario = false;
        private bool mostrarErrorNombre = false;
        private bool mostrarErrorCorreo = false;
        private bool mostrarErrorTelefono = false;
        private string mensajeError = "";

        protected override async Task OnInitializedAsync()
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            usuarios = await UsuarioService.GetUsuariosAsync();
        }

        private void MostrarFormularioAgregar()
        {
            usuarioSeleccionado = new Usuario();
            mensajeError = "";
            mostrarErrorNombre = false;
            mostrarErrorCorreo = false;
            mostrarErrorTelefono = false;
            mostrandoFormulario = true;
        }

        private void EditarUsuario(Usuario usuario)
        {
            usuarioSeleccionado = new Usuario
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono
            };
            mensajeError = "";
            mostrandoFormulario = true;
        }

        private async Task GuardarUsuario(Usuario usuario)
        {
            mensajeError = "";
            mostrarErrorNombre = string.IsNullOrWhiteSpace(usuario.Nombre);
            mostrarErrorCorreo = string.IsNullOrWhiteSpace(usuario.Correo);
            mostrarErrorTelefono = string.IsNullOrWhiteSpace(usuario.Telefono);

            if (mostrarErrorNombre || mostrarErrorCorreo || mostrarErrorTelefono)
            {
                return;
            }

            bool success;

            if (usuario.Id == 0)
            {
                success = await UsuarioService.CreateUsuarioAsync(usuario);
            }
            else
            {
                success = await UsuarioService.UpdateUsuarioAsync(usuario.Id, usuario);
            }

            if (!success)
            {
                mensajeError = "El correo o el teléfono ya están en uso.";
                return;
            }

            mostrandoFormulario = false;
            await CargarUsuarios();
            StateHasChanged();
        }

        private async Task EliminarUsuario(int id)
        {
            if (await UsuarioService.DeleteUsuarioAsync(id))
            {
                await CargarUsuarios();
                StateHasChanged();
            }
        }

        private void CancelarEdicion()
        {
            mostrandoFormulario = false;
            mensajeError = "";
            StateHasChanged();
        }
    }
}
