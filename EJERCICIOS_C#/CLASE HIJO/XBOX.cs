using EJERCICIOS_C_.CLASE_PADRE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS_C_.CLASE_HIJO
{
    internal class XBOX : ClsConsola
    {
        public string kinect {  get; set; }
        public string MostrarDetallesXBox()
        {
            return "Extras: " + kinect;
        }
    }
}