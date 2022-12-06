using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = context.RolGetAll().ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = item.IdRol;
                            rol.Nombre = item.Nombre;

                            result.Objects.Add(rol);
                        }

                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de usuarios" + result.Ex;

                throw;
            }
            return result;
        }
    }
}
