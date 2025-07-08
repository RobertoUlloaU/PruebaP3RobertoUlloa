using System.ComponentModel;
using System.Runtime.CompilerServices;
using PruebaP3RobertoUlloa.Models;

namespace PruebaP3RobertoUlloa.ViewModels
{
    public class DispositivoViewModel : INotifyPropertyChanged
    {
        // Implementa la interfaz INotifyPropertyChanged para que la vista se actualice cuando cambien las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        private Dispositivo _dispositivo;
        public Dispositivo Dispositivo
        {
            get => _dispositivo;
            set
            {
                _dispositivo = value;
                OnPropertyChanged();
            }
        }

        private bool _garantiaActiva;
        public bool GarantiaActiva
        {
            get => _garantiaActiva;
            set
            {
                _garantiaActiva = value;
                Dispositivo.GarantiaActiva = value;
                OnPropertyChanged();
                // Actualiza la lógica de la vida útil dependiendo de la garantía
                if (value && Dispositivo.VidaUtilMeses < 12)
                {
                    Dispositivo.VidaUtilMeses = 12; // Si tiene garantía, vida útil mínima es 12
                }
            }
        }

        public DispositivoViewModel()
        {
            // Inicializa el dispositivo
            Dispositivo = new Dispositivo
            {
                Nombre = string.Empty,
                Marca = string.Empty,
                GarantiaActiva = false,
                VidaUtilMeses = 12
            };
        }

        // Método para manejar la lógica de guardado o procesamiento de datos
        public void SaveDevice()
        {
            // Aquí va la lógica para guardar el dispositivo, ya sea en una base de datos o archivo.
            // Por ahora, solo simula un guardado
            System.Diagnostics.Debug.WriteLine($"Dispositivo guardado: {Dispositivo.Nombre}, {Dispositivo.Marca}, {Dispositivo.GarantiaActiva}, {Dispositivo.VidaUtilMeses} meses.");
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

