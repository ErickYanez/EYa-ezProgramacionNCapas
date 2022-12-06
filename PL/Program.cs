using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Seleccione una opción a utilizar: ");
            Console.WriteLine("1 - Insertar Usuario \n2 - Mostrar Usuarios \n3 - Mostrar usuario por Id \n4 - Actualizar Usuario \n5 - Eliminar Usuario \n ----------------------- \n6 - Insertar Empresa \n7 - Mostrar Empresa \n8 - Mostrar Empresa por Id \n9 - Actualizar Empresa \n10 - Eliminar Empresa \n11 - Salir");
            int Opcion = int.Parse(Console.ReadLine());
            switch (Opcion)
            {
                case 1:
                    Console.WriteLine("");
                    Usuario.Add();
                    break;
                case 2:
                    Console.WriteLine("");
                    Usuario.GetAll();
                    break;
                case 3:
                    Console.WriteLine("");
                    Usuario.GetById();
                    break;
                case 4:
                    Console.WriteLine("");
                    Usuario.Update();
                    break;
                case 5:
                    Console.WriteLine("");
                    Usuario.Delete();
                    break;
                case 6:
                    Console.WriteLine("");
                    Empresa.Add();
                    break;
                case 7:
                    Console.WriteLine("");
                    Empresa.GetAll();
                    break;
                case 8:
                    Console.WriteLine("");
                    Empresa.GetById();
                    break;
                case 9:
                    Console.WriteLine("");
                    Empresa.Update();
                    break;
                case 10:
                    Console.WriteLine("");
                    Empresa.Delete();
                    break;
                case 11:
                    Console.WriteLine("");
                    Console.Write("      °º¤ø,¸¸,ø¤º°`°º¤ø,¸( Hasta la próxima )¸,ø¤º°`°º¤ø,¸,ø¤º°");
                    break;
            }
            Console.ReadKey();
        }
    }
}
