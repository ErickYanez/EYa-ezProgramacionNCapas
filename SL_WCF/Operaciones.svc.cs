using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public int sumar(int numero1, int numero2)
        {
            return numero1 + numero2;
        }

        public int restar(int numero1, int numero2)
        {
            return numero1 - numero2;
        }

        public int multiplicar(int numero1, int numero2)
        {
            return numero1 * numero2;
        }

        public int dividir(int numero1, int numero2)
        {
            return numero1 / numero2;
        }

        public string saludar(string nombre)
        {
            return "Hola" + nombre;
        }
    }
}
