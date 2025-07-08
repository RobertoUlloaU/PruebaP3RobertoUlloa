using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP3RobertoUlloa.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public bool GarantiaActiva { get; set; }
        public int VidaUtilMeses { get; set; }
    }

}
