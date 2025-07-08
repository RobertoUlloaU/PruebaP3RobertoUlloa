using Microsoft.Maui.Controls;

namespace PruebaP3RobertoUlloa
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        // Método que se ejecuta cuando se hace clic en el botón "Guardar"
        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Obtener los datos de los campos
            string nombre = NombreEntry.Text;
            string marca = MarcaEntry.Text;
            int vidaUtil;

            // Validar si los campos no están vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(marca))
            {
                await DisplayAlert("Error", "Por favor ingresa todos los campos.", "OK");
                return;
            }

            // Validar que la vida útil sea un número
            if (!int.TryParse(VidaUtilEntry.Text, out vidaUtil))
            {
                await DisplayAlert("Error", "La vida útil debe ser un número válido.", "OK");
                return;
            }

            // Obtener el estado del interruptor para saber si tiene garantía
            bool garantiaActiva = GarantiaSwitch.IsToggled;

            // Aquí puedes agregar la lógica para guardar estos datos en la base de datos o archivo
            // Por ejemplo, se simula que los datos fueron guardados con un mensaje de éxito
            await DisplayAlert("Éxito", "Dispositivo guardado correctamente.", "OK");
        }
    }
}



