using BL;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Usuario
    {
        public static void Add()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Registrar Usuario \n");

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del usuario (H-M)");
            usuario.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de nacimiento del usuario (DD/MM/YYYY)");
            usuario.FechaNacimiento =  Console.ReadLine();

            Console.WriteLine("Ingrese el password del usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP del usuario");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingrese el Nombre de usuario del usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el email del usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el Rol del usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Add(usuario);
            //ML.Result result = BL.Usuario.AddSP(usuario);
            //ML.Result result = BL.Usuario.AddEF(usuario);
            ML.Result result = BL.Usuario.AddLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }

        public static void GetAll()
        {
            //ML.Result result = BL.Usuario.GetAll();
            //ML.Result result = BL.Usuario.GetAllEF();
            ML.Result result = BL.Usuario.GetAllLINQ();
            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine(" {IdUsuario}: " + usuario.IdUsuario);
                    Console.WriteLine(" {Nombre}: " + usuario.Nombre);
                    Console.WriteLine(" {Apellido Paterno}: " + usuario.ApellidoPaterno);
                    Console.WriteLine(" {Apellido Materno}: " + usuario.ApellidoMaterno);
                    Console.WriteLine(" {Sexo}: " + usuario.Sexo);
                    Console.WriteLine(" {Fecha Nacimiento}: " + usuario.FechaNacimiento);
                    Console.WriteLine(" {Password}: " + usuario.Password);
                    Console.WriteLine(" {Telefono}: " + usuario.Telefono);
                    Console.WriteLine(" {Celular}: " + usuario.Celular);
                    Console.WriteLine(" {CURP}: " + usuario.CURP);
                    Console.WriteLine(" {UserName}: " + usuario.UserName);
                    Console.WriteLine(" {Email}: " + usuario.Email);
                    Console.WriteLine(" {IdRol}: " + usuario.Rol.IdRol);
                    Console.WriteLine("**********************************");
                }
            }
            Console.ReadKey();
        }

        public static void GetById()
        {

            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Mostrar Usuario por Id \n");

            Console.WriteLine("Ingrese el Id del alumno que desea mostrar");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.GetById(usuario.IdUsuario);
            //ML.Result result = BL.Usuario.GetByIdEF(usuario.IdUsuario);
            ML.Result result = BL.Usuario.GetByIdLINQ(usuario.IdUsuario);

            if (result.Correct)
            {

                usuario = (ML.Usuario)result.Objeto;

                Console.WriteLine(" {IdUsuario}: " + usuario.IdUsuario);
                Console.WriteLine(" {Nombre}: " + usuario.Nombre);
                Console.WriteLine(" {Apellido Paterno}: " + usuario.ApellidoPaterno);
                Console.WriteLine(" {Apellido Materno}: " + usuario.ApellidoMaterno);
                Console.WriteLine(" {Sexo}: " + usuario.Sexo);
                Console.WriteLine(" {Fecha Nacimiento}: " + usuario.FechaNacimiento);
                Console.WriteLine(" {Password}: " + usuario.Password);
                Console.WriteLine(" {Telefono}: " + usuario.Telefono);
                Console.WriteLine(" {Celular}: " + usuario.Celular);
                Console.WriteLine(" {CURP}: " + usuario.CURP);
                Console.WriteLine(" {UserName}: " + usuario.UserName);
                Console.WriteLine(" {Email}: " + usuario.Email);
                Console.WriteLine(" {IdRol}: " + usuario.Rol.IdRol);
                Console.WriteLine("**********************************");
            }
            Console.ReadKey();
        }

        public static void Update()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Actualizar Usuario \n");

            Console.WriteLine("Ingrese el Id del alumno que desea actualizar");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre del usuario");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del usuario (H-M)");
            usuario.Sexo = char.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la fecha de nacimiento del usuario (DD/MM/YYYY)");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el password del usuario");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del usuario");
            usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el celular del usuario");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese el CURP del usuario");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("Ingrese el Nombre de usuario del usuario");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el email del usuario");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el Rol del usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Update(usuario);
            //ML.Result result = BL.Usuario.UpdateSP(usuario);
            //ML.Result result = BL.Usuario.UpdateEF(usuario);
            ML.Result result = BL.Usuario.UpdateLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }
        
        public static void Delete()
        {
            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Eliminar Usuario \n");

            Console.WriteLine("Ingrese el Id del usuario que desea eliminar");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            //ML.Result result = BL.Usuario.Delete(usuario);
            //ML.Result result = BL.Usuario.DeleteSP(usuario);
            ML.Result result = BL.Usuario.DeleteLINQ(usuario);

            if (result.Correct)
            {
                Console.WriteLine("Mensaje: " + result.Message);
            }

            Console.ReadKey();
        }

    }
}
