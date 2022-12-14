using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Aseguradora
    {
        public static ML.Result Add(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraAdd(aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "Se agrego la aseguradora correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la aseguradora" + result.Ex;

                throw;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = context.AseguradoraGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Aseguradora aseguradora = new ML.Aseguradora();

                            aseguradora.IdAseguradora = item.IdAseguradora;
                            aseguradora.Nombre = item.Nombre;
                            aseguradora.FechaCreacion = item.FechaCreacion.ToString();
                            aseguradora.FechaModificacion = item.FechaModificacion.ToString();

                            aseguradora.Usuario = new ML.Usuario();
                            aseguradora.Usuario.IdUsuario = item.IdUsuario.Value;
                            aseguradora.Usuario.Nombre = item.NombreUsuario;
                            aseguradora.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                            aseguradora.Usuario.ApellidoMaterno = item.ApellidoMaterno;
                            result.Objects.Add(aseguradora);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de aseguradoras" + result.Ex;

                throw;
            }
            return result;
        }
        public static ML.Result GetById(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var item = context.AseguradoraGetById(idAseguradora).SingleOrDefault();
                    if (item != null)
                    {
                        ML.Aseguradora aseguradora = new ML.Aseguradora();

                        aseguradora.IdAseguradora = item.IdAseguradora;
                        aseguradora.Nombre = item.Nombre;
                        aseguradora.FechaCreacion = item.FechaCreacion.ToString();
                        aseguradora.FechaModificacion = item.FechaModificacion.ToString();

                        aseguradora.Usuario = new ML.Usuario();
                        aseguradora.Usuario.IdUsuario = item.IdUsuario.Value;
                        aseguradora.Usuario.Nombre = item.NombreUsuario;
                        aseguradora.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                        aseguradora.Usuario.ApellidoMaterno = item.ApellidoMaterno;

                        result.Objeto = aseguradora;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la aseguradora" + result.Ex;

                throw;
            }
            return result;
        }
        public static ML.Result Update(ML.Aseguradora aseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraUpdate(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Usuario.IdUsuario);

                    if (query > 0)
                    {
                        result.Message = "Se actualizo la aseguradora correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar la aseguradora" + result.Ex;

                throw;
            }
            return result;
        }
        public static ML.Result Delete(int idAseguradora)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.AseguradoraDelete(idAseguradora);

                    if (query > 0)
                    {
                        result.Message = "Se elimino la aseguradora correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la aseguradora" + result.Ex;

                throw;
            }
            return result;
        }
    }
}
