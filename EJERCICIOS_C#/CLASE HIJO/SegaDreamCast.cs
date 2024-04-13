using EJERCICIOS_C_.CLASE_PADRE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS_C_.CLASE_HIJO
{

    internal class SegaDreamCast : ClsConsola
    {
        public string Color { get; set; }

        public String MostrarDetalleSega()
        {
            return MostrarDetalles() + "Colores:" + Color;
        }

    }
}
