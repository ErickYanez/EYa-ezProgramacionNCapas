using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using DL_EF;
using System.Runtime.Remoting.Contexts;

namespace BL
{
    public class Empresa
    {
        public static ML.Result Add(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[4];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = empresa.Nombre;

                        collection[1] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[1].Value = empresa.Telefono;

                        collection[2] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[2].Value = empresa.Email;

                        collection[3] = new SqlParameter("DireccionWeb", SqlDbType.VarChar);
                        collection[3].Value = empresa.DireccionWeb;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego la empresa correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable empresaTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(empresaTable);

                        if (empresaTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow reader in empresaTable.Rows)
                            {
                                ML.Empresa empresa = new ML.Empresa();

                                empresa.IdEmpresa = int.Parse(reader[0].ToString());
                                empresa.Nombre = reader[1].ToString();
                                empresa.Telefono = reader[2].ToString();
                                empresa.Email = reader[3].ToString();
                                empresa.DireccionWeb = reader[4].ToString();

                                result.Objects.Add(empresa);
                            }
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de empresas" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetById(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.TinyInt);
                        collection[0].Value = idEmpresa;

                        cmd.Parameters.AddRange(collection);

                        DataTable empresaTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(empresaTable);

                        if (empresaTable.Rows.Count > 0)
                        {
                            DataRow row = empresaTable.Rows[0];

                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = int.Parse(row[0].ToString());
                            empresa.Nombre = row[1].ToString();
                            empresa.Telefono = row[2].ToString();
                            empresa.Email = row[3].ToString();
                            empresa.DireccionWeb = row[4].ToString();

                            result.Objeto = empresa;
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.Int);
                        collection[0].Value = empresa.IdEmpresa;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = empresa.Nombre;

                        collection[2] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[2].Value = empresa.Telefono;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = empresa.Email;

                        collection[4] = new SqlParameter("DireccionWeb", SqlDbType.VarChar);
                        collection[4].Value = empresa.DireccionWeb;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo la empresa correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result Delete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "EmpresaDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdEmpresa", SqlDbType.TinyInt);
                        collection[0].Value = empresa.IdEmpresa;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino la empresa correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        //ENTITY FRAMEWORK

        public static ML.Result AddEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

                    if (query > 0)
                    {
                        result.Message = "Se agrego la empresa correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Empresa empresaa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = context.EmpresaGetAll(empresaa.Nombre).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;
                            empresa.Logo = item.Logo;

                            result.Objects.Add(empresa);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de empresas" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var item = context.EmpresaGetById(idEmpresa).SingleOrDefault();

                    if (item != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa = item.IdEmpresa;
                        empresa.Nombre = item.Nombre;
                        empresa.Telefono = item.Telefono;
                        empresa.Email = item.Email;
                        empresa.DireccionWeb = item.DireccionWeb;
                        empresa.Logo = item.Logo;

                        result.Objeto = empresa;       
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.EmpresaUpdate(empresa.IdEmpresa, empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb, empresa.Logo);

                    if (query > 0)
                    {
                        result.Message = "Se actualizo la empresa correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.EmpresaDelete(empresa.IdEmpresa);

                    if (query > 0)
                    {
                        result.Message = "Se elimino la empresa correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    DL_EF.Empresa empresaDL = new DL_EF.Empresa();

                    empresaDL.Nombre = empresa.Nombre;
                    empresaDL.Telefono = empresa.Telefono;
                    empresaDL.Email = empresa.Email;
                    empresaDL.DireccionWeb = empresa.DireccionWeb;

                    context.Empresas.Add(empresaDL);
                    int resp = context.SaveChanges();

                    if (resp > 0)
                    {
                        result.Message = "Se agrego la empresa correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from empresaLINQ in context.Empresas select new { IdEmpresa = empresaLINQ.IdEmpresa, Nombre = empresaLINQ.Nombre, Telefono = empresaLINQ.Telefono, Email = empresaLINQ.Email, DireccionWeb = empresaLINQ.DireccionWeb});

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Telefono = item.Telefono;
                            empresa.Email = item.Email;
                            empresa.DireccionWeb = item.DireccionWeb;

                            result.Objects.Add(empresa);
                        }
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la lista de empresas" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetByIdLINQ(int idEmpresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from empresaLINQ in context.Empresas where empresaLINQ.IdEmpresa == idEmpresa select new { IdEmpresa = empresaLINQ.IdEmpresa, Nombre = empresaLINQ.Nombre, Telefono = empresaLINQ.Telefono, Email = empresaLINQ.Email, DireccionWeb = empresaLINQ.DireccionWeb }).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Empresa empresa = new ML.Empresa();

                        empresa.IdEmpresa = query.IdEmpresa;
                        empresa.Nombre = query.Nombre;
                        empresa.Telefono = query.Telefono;
                        empresa.Email = query.Email;
                        empresa.DireccionWeb = query.DireccionWeb;

                        result.Objeto = empresa;
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al mostrar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result UpdateLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from Empresa in context.Empresas where Empresa.IdEmpresa == empresa.IdEmpresa select Empresa).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = empresa.Nombre;
                        query.Telefono = empresa.Telefono;
                        query.Email = empresa.Email;
                        query.DireccionWeb = empresa.DireccionWeb;

                        context.SaveChanges();
                        result.Message = "Se actualizo la empresa correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar la empresa" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from Empresa in context.Empresas where Empresa.IdEmpresa == empresa.IdEmpresa select Empresa).SingleOrDefault();

                    context.Empresas.Remove(query);
                    int resp = context.SaveChanges();

                    if (resp > 0)
                    {
                        result.Message = "Se elimino la empresa correctamente";
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar la empresa" + result.Ex;

                throw;
            }
            return result;
        }
    }
}
