using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejerecicio_Clase.Clases
{
    internal class Carro
    {
        public string Marca { get; }
        public int Modelo { get; }
        public string Color {  get; set; }
        public string Owner { get; set; }

        private bool Encendido = false;
        public int Velocidad_Actual {get; set; }
        public int MAXVELOCIDAD {  get; set; }

        public Carro(string m, int model)
        {
            Marca = m;
            Modelo = model;
        }
        public int Acelerar()
        {
            if (!Encendido) // Si no está encendido, retornamos 0
            {
                return 0;
            }

            Velocidad_Actual =+ 10; // Aumentamos la velocidad en 20

            if (Velocidad_Actual > MAXVELOCIDAD)
            {
                Velocidad_Actual = MAXVELOCIDAD;
            }

            return Velocidad_Actual;
        }

        public void Encender()
        {
            Encendido = true;
        }

        public void Apagar()
        {
            if (Encendido && Velocidad_Actual == 0)
            {
                Encendido = false;
            }
        }
    }
}