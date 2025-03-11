using Agenda.Shared.Model;
using System.Net.Http.Json;

namespace Agenda.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService(HttpClient httpClient)
        {
            httpClient.BaseAddress ??= new Uri("https://localhost:7075/");
            _httpClient = httpClient;
        }

        public async Task<List<Usuario>?> GetUsuariosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<List<Usuario>>>("api/Usuarios");
            return response?.Data;
        }

        public async Task<Usuario?> GetUsuarioAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ApiResponse<Usuario>>($"api/Usuarios/{id}");
            return response?.Data;
        }

        public async Task<bool> CreateUsuarioAsync(Usuario usuario)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Usuarios", usuario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateUsuarioAsync(int id, Usuario usuario)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Usuarios/{id}", usuario);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUsuarioAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Usuarios/{id}");
            return response.IsSuccessStatusCode;
        }
    }

    public class ApiResponse<T>
    {
        public T Data { get; set; } = default!;
        public string TiempoEjecucion { get; set; } = string.Empty;
    }
}
