using EJERCICIOS_C_.CLASE_PADRE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS_C_.CLASE_HIJO
{
    internal class PlayStation: ClsConsola
    {
        public string ModeloControlador {  get; set; }
        public String MostrarDetallePlay()
        {
            return MostrarDetalles() + "Controlador: " + ModeloControlador;
        }
    }
}
