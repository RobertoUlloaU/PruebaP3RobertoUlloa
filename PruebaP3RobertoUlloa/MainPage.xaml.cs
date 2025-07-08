using Microsoft.Maui.Controls;
using PruebaP3RobertoUlloa.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

namespace PruebaP3RobertoUlloa
{
    public partial class MainPage : ContentPage
    {
        private readonly DatabaseHelper _database;

        public MainPage()
        {
            InitializeComponent();
            _database = new DatabaseHelper(App.DatabasePath);
        }

        private async void OnGuardarClicked(object sender, EventArgs e)
        {
            // Validar la vida útil
            int vidaUtil;
            if (!int.TryParse(VidaUtilEntry.Text, out vidaUtil))
            {
                await DisplayAlert("Error", "La vida útil debe ser un número.", "OK");
                return;
            }

            if (GarantiaSwitch.IsToggled && vidaUtil < 12)
            {
                await DisplayAlert("Error", "Si la garantía está activa, la vida útil debe ser al menos 12 meses.", "OK");
                return;
            }

            var dispositivo = new Dispositivo
            {
                Nombre = NombreEntry.Text,
                Marca = MarcaEntry.Text,
                GarantiaActiva = GarantiaSwitch.IsToggled,
                VidaUtilMeses = vidaUtil
            };

            _database.SaveDispositivo(dispositivo);
            await GuardarLog(dispositivo.Nombre);
            await DisplayAlert("Éxito", "Dispositivo guardado correctamente", "OK");
        }

        private async Task GuardarLog(string nombreDispositivo)
        {
            var logPath = Path.Combine(FileSystem.AppDataDirectory, $"Logs_Ulloa.txt");
            var logMessage = $"Se incluyó el registro {nombreDispositivo} el {DateTime.Now:dd/MM/yyyy hh:mm}";
            await File.AppendAllTextAsync(logPath, logMessage + Environment.NewLine);
        }
    }
}



