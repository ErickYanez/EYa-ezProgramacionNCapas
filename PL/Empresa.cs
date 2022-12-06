using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Empresa
    {
        public static void Add()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Registrar Empresa \n");

            Console.WriteLine("Ingrese el nombre de la empresa");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono de la empresa");
            empresa.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el email de la empresa");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la direccionweb de la empresa");
            empresa.DireccionWeb = Console.ReadLine();

            //ML.Result result = BL.Empresa.Add(empresa);
            //ML.Result result = BL.Empresa.AddEF(empresa);
            ML.Result result = BL.Empresa.AddLINQ(empresa);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Empresa.GetAll();
            //ML.Result result = BL.Empresa.GetAllEF();
            ML.Result result = BL.Empresa.GetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine(" {IdEmpresa}: " + empresa.IdEmpresa);
                    Console.WriteLine(" {Nombre}: " + empresa.Nombre);
                    Console.WriteLine(" {Telefono}: " + empresa.Telefono);
                    Console.WriteLine(" {Email}: " + empresa.Email);
                    Console.WriteLine(" {DireccionWeb}: " + empresa.DireccionWeb);
                    Console.WriteLine("**********************************");
                }
            }
            Console.ReadKey();
        }

        public static void GetById()
        {

            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Mostrar Empresa por Id \n");

            Console.WriteLine("Ingrese el Id de la empresa que desea mostrar");
            empresa.IdEmpresa = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Empresa.GetById(empresa.IdEmpresa);
            //ML.Result result = BL.Empresa.GetByIdEF(empresa.IdEmpresa);
            ML.Result result = BL.Empresa.GetByIdLINQ(empresa.IdEmpresa);

            if (result.Correct)
            {

                empresa = (ML.Empresa)result.Objeto;

                Console.WriteLine(" {IdEmpresa}: " + empresa.IdEmpresa);
                Console.WriteLine(" {Nombre}: " + empresa.Nombre);
                Console.WriteLine(" {Telefono}: " + empresa.Telefono);
                Console.WriteLine(" {Email}: " + empresa.Email);
                Console.WriteLine(" {DireccionWeb}: " + empresa.DireccionWeb);
                Console.WriteLine("**********************************");
            }
            Console.ReadKey();
        }

        public static void Update()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Actualizar Empresa \n");

            Console.WriteLine("Ingrese el Id de la empresa que desea actualizar");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre de la empresa");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono de la empresa");
            empresa.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el email de la empresa");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la direccionweb de la empresa");
            empresa.DireccionWeb = Console.ReadLine();

            //ML.Result result = BL.Empresa.Update(empresa);
            ML.Result result = BL.Empresa.UpdateEF(empresa);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }

        public static void Delete()
        {
            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Eliminar Empresa \n");

            Console.WriteLine("Ingrese el Id de la empresa que desea eliminar");
            empresa.IdEmpresa = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(usuario);
            ML.Result result = BL.Empresa.Delete(empresa);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }
    }
}
