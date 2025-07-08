using Microsoft.Maui.Controls;
using System.IO;
using Microsoft.Maui.Storage;
using PruebaP3RobertoUlloa.Models;

namespace PruebaP3RobertoUlloa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, "Dispositivos.db3");
    }
}

