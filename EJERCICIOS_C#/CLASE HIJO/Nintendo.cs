using EJERCICIOS_C_.CLASE_PADRE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS_C_.CLASE_HIJO
{
    internal class Nintendo:ClsConsola
    {
        public bool esPortable { get; set; }
        public string MostrarDetalleNintendo()
        {
            string detallePadre = MostrarDetalleNintendo();
            return detallePadre + "Es portable: " + esPortable;
        }
    }
}