using System.Net.Http.Json;

namespace APP_TO_DO.MOBILE.Services
{
    public class Recordatorio
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public DateTime Fecha { get; set; }
    }

    public class RecordatorioService
    {
        private readonly HttpClient _httpClient;

        public RecordatorioService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        // Obtener todos los recordatorios (GET /api/recordatorios)
        public async Task<List<Recordatorio>> ObtenerRecordatoriosAsync()
        {
            try
            {
                var resultado = await _httpClient.GetFromJsonAsync<List<Recordatorio>>("api/recordatorios");
                return resultado ?? new List<Recordatorio>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener recordatorios: {ex.Message}");
                return new List<Recordatorio>();
            }
        }

        // Crear un nuevo recordatorio (POST /api/recordatorios)
        public async Task<bool> CrearRecordatorioAsync(Recordatorio nuevoRecordatorio)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/recordatorios", nuevoRecordatorio);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear recordatorio: {ex.Message}");
                return false;
            }
        }
    }
}