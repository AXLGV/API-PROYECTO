using APP_TO_DO.MOBILE.Services;

namespace APP_TO_DO.MOBILE
{
    public partial class MainPage : ContentPage
    {
        private readonly RecordatorioService _recordatorioService;

        public MainPage(RecordatorioService recordatorioService)
        {
            InitializeComponent();
            _recordatorioService = recordatorioService;

            // Cargar los recordatorios apenas se abre la app
            CargarRecordatorios();
        }

        private async void CargarRecordatorios()
        {
            LoadingIndicator.IsRunning = true;
            LoadingIndicator.IsVisible = true;

            var recordatorios = await _recordatorioService.ObtenerRecordatoriosAsync();
            ListaRecordatorios.ItemsSource = recordatorios;

            LoadingIndicator.IsRunning = false;
            LoadingIndicator.IsVisible = false;
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EntryTitulo.Text))
            {
                await DisplayAlert("Aviso", "El título es obligatorio", "OK");
                return;
            }

            var nuevoRecordatorio = new Recordatorio
            {
                Titulo = EntryTitulo.Text,
                Descripcion = EntryDescripcion.Text ?? string.Empty,
                Fecha = DateTime.Now
            };

            var exito = await _recordatorioService.CrearRecordatorioAsync(nuevoRecordatorio);

            if (exito)
            {
                EntryTitulo.Text = string.Empty;
                EntryDescripcion.Text = string.Empty;
                await DisplayAlert("Éxito", "Recordatorio guardado", "OK");
                CargarRecordatorios();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo guardar el recordatorio. Verifica que la API esté corriendo.", "OK");
            }
        }

        private void OnActualizarClicked(object sender, EventArgs e)
        {
            CargarRecordatorios();
        }
    }
}