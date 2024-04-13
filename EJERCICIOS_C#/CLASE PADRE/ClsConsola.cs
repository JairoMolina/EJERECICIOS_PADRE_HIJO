using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIOS_C_.CLASE_PADRE
{
    internal class ClsConsola
    {
        public int anioLanzamiento { get; set; }
        public string Marca {  get; set; }
        public String MostrarDetalles()
        {
            return ($"Marca: {Marca} Año: {anioLanzamiento}");
        }
    }
}
