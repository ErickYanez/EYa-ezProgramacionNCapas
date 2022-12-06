using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using DL_EF;
using System.Data.Entity.Infrastructure;

namespace BL
{
    public class Usuario
    {
        //CONSULTA
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno],[Sexo],[FechaNacimiento],[Password],[Telefono],[Celular],[CURP],[UserName],[Email],[IdRol])VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sexo,CONVERT(DATE, @FechaNacimiento,105),@Password,@Telefono,@Celular,@CURP,@UserName,@Email,@IdRol)";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[3].Value = usuario.Sexo;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[7].Value = usuario.CURP;

                        collection[8] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[9].Value = usuario.UserName;

                        collection[10] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[10].Value = usuario.Email;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UPDATE [Usuario] SET [Nombre] = @Nombre,[ApellidoPaterno] = @ApellidoPaterno,[ApellidoMaterno] = @ApellidoMaterno,[Sexo] = @Sexo,[FechaNacimiento] = CONVERT(DATE, @FechaNacimiento,105),[Password] = @Password,[Telefono] = @Telefono,[Celular] = @Celular,[CURP] = @CURP,[UserName] =@UserName,[Email] = @Email,[IdRol] = @IdRol WHERE Usuario.[IdUsuario] = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[5].Value = usuario.FechaNacimiento;

                        collection[6] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[8].Value = usuario.CURP;

                        collection[9] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[9].Value = usuario.Password;

                        collection[10] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[10].Value = usuario.UserName;

                        collection[11] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[11].Value = usuario.Email;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "DELETE FROM [Usuario] WHERE Usuario.[IdUsuario] = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        //STORE PROCEDURE



        public static ML.Result AddSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioAdd";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[12];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[3].Value = usuario.Sexo;

                        collection[4] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[4].Value = usuario.FechaNacimiento;

                        collection[5] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[5].Value = usuario.Telefono;

                        collection[6] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[6].Value = usuario.Password;

                        collection[7] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[7].Value = usuario.CURP;

                        collection[8] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[8].Value = usuario.Password;

                        collection[9] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[9].Value = usuario.UserName;

                        collection[10] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[10].Value = usuario.Email;

                        collection[11] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[11].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se agrego el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

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
                    string query = "UsuarioGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow reader in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = byte.Parse(reader[0].ToString());
                                usuario.Nombre = reader[1].ToString();
                                usuario.ApellidoPaterno = reader[2].ToString();
                                usuario.ApellidoMaterno = reader[3].ToString();
                                usuario.Sexo = char.Parse(reader[4].ToString().Trim());
                                usuario.FechaNacimiento = reader[5].ToString();
                                usuario.Password = reader[6].ToString();
                                usuario.Telefono = reader[7].ToString();
                                usuario.Celular = reader[8].ToString();
                                usuario.CURP = reader[9].ToString();
                                usuario.UserName = reader[10].ToString();
                                usuario.Email = reader[11].ToString();

                                usuario.Rol = new ML.Rol();
                                usuario.Rol.IdRol = byte.Parse(reader[12].ToString());

                                result.Objects.Add(usuario);
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
                result.Message = "Ocurrio un error al mostrar la lista de usuarios" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetById(byte idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = idUsuario;

                        cmd.Parameters.AddRange(collection);

                        DataTable usuarioTable = new DataTable();

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(usuarioTable);

                        if (usuarioTable.Rows.Count > 0)
                        {
                            DataRow row = usuarioTable.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = byte.Parse(row[0].ToString());
                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.Sexo = char.Parse(row[4].ToString().Trim());
                            usuario.FechaNacimiento = row[5].ToString();
                            usuario.Password = row[6].ToString();
                            usuario.Telefono = row[7].ToString();
                            usuario.Celular = row[8].ToString();
                            usuario.CURP = row[9].ToString();
                            usuario.UserName = row[10].ToString();
                            usuario.Email = row[11].ToString();
                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = byte.Parse(row[12].ToString());

                            result.Objeto = usuario;
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

        public static ML.Result DeleteSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioDelete";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se elimino el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result UpdateSP(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConexion()))
                {
                    string query = "UsuarioUpdate";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        context.Open();

                        SqlParameter[] collection = new SqlParameter[13];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.TinyInt);
                        collection[0].Value = usuario.IdUsuario;

                        collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[1].Value = usuario.Nombre;

                        collection[2] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoPaterno;

                        collection[3] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[3].Value = usuario.ApellidoMaterno;

                        collection[4] = new SqlParameter("Sexo", SqlDbType.Char);
                        collection[4].Value = usuario.Sexo;

                        collection[5] = new SqlParameter("FechaNacimiento", SqlDbType.VarChar);
                        collection[5].Value = usuario.FechaNacimiento;

                        collection[6] = new SqlParameter("Telefono", SqlDbType.VarChar);
                        collection[6].Value = usuario.Telefono;

                        collection[7] = new SqlParameter("Celular", SqlDbType.VarChar);
                        collection[7].Value = usuario.Password;

                        collection[8] = new SqlParameter("CURP", SqlDbType.VarChar);
                        collection[8].Value = usuario.CURP;

                        collection[9] = new SqlParameter("Password", SqlDbType.VarChar);
                        collection[9].Value = usuario.Password;

                        collection[10] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[10].Value = usuario.UserName;

                        collection[11] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[11].Value = usuario.Email;

                        collection[12] = new SqlParameter("IdRol", SqlDbType.TinyInt);
                        collection[12].Value = usuario.Rol.IdRol;

                        cmd.Parameters.AddRange(collection);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected >= 1)
                        {
                            result.Message = "Se actualizo el usuario correctamente";
                        }
                    }

                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        //ENTITY FRAMEWORK

        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Sexo.ToString(), usuario.FechaNacimiento, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.UserName, usuario.Email, usuario.Rol.IdRol,null,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "Se agrego el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    usuario.Rol.IdRol = (byte)((usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol);
                    usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
                    usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
                    var query = context.UsuarioGetAll(usuario.Nombre, usuario.ApellidoPaterno, usuario.Rol.IdRol).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var item in query)
                        {
                             ML.Usuario usuarioo = new ML.Usuario();

                            usuarioo.IdUsuario = item.IdUsuario;
                            usuarioo.Nombre = item.Nombre;
                            usuarioo.ApellidoPaterno = item.ApellidoPaterno;
                            usuarioo.ApellidoMaterno = item.ApellidoMaterno;
                            usuarioo.Sexo = char.Parse(item.Sexo.ToString().Trim());
                            usuarioo.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                            usuarioo.Password = item.Password;
                            usuarioo.Telefono = item.Telefono;
                            usuarioo.Celular = item.Celular;
                            usuarioo.CURP = item.CURP;
                            usuarioo.UserName = item.UserName;
                            usuarioo.Email = item.Email;
                            usuarioo.Imagen = item.Imagen;
                            usuarioo.Status = item.Status.Value;

                            usuarioo.NombreCompleto = $"{item.Nombre},{item.ApellidoPaterno},{item.ApellidoMaterno}";

                            usuarioo.Rol = new ML.Rol();
                            usuarioo.Rol.IdRol = item.IdRol.Value;
                            usuarioo.Rol.Nombre = item.NombreRol;

                            usuarioo.Direccion = new ML.Direccion();
                            usuarioo.Direccion.IdDireccion = item.IdDireccion;
                            usuarioo.Direccion.Calle = item.Calle;
                            usuarioo.Direccion.NumeroInterior = item.NumeroInterior;
                            usuarioo.Direccion.NumeroExterior = item.NumeroExterior;

                            usuarioo.Direccion.Colonia = new ML.Colonia();
                            usuarioo.Direccion.Colonia.IdColonia = item.IdColonia.Value;
                            usuarioo.Direccion.Colonia.Nombre = item.NombreColonia;
                            usuarioo.Direccion.Colonia.CodigoPostal = item.CodigoPostal;

                            usuarioo.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioo.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio.Value;
                            usuarioo.Direccion.Colonia.Municipio.Nombre = item.NombreMunicipio;

                            usuarioo.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioo.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado.Value;
                            usuarioo.Direccion.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                            usuarioo.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioo.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais.Value;
                            usuarioo.Direccion.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                            result.Objects.Add(usuarioo);
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

        public static ML.Result GetByIdEF(byte idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var item = context.UsuarioGetById(idUsuario).SingleOrDefault();

                    if (item != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = item.IdUsuario;
                        usuario.Nombre = item.Nombre;
                        usuario.ApellidoPaterno = item.ApellidoPaterno;
                        usuario.ApellidoMaterno = item.ApellidoMaterno;
                        usuario.Sexo = char.Parse(item.Sexo.ToString().Trim());
                        usuario.FechaNacimiento = item.FechaNacimiento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                        usuario.Password = item.Password;
                        usuario.Telefono = item.Telefono;
                        usuario.Celular = item.Celular;
                        usuario.CURP = item.CURP;
                        usuario.UserName = item.Username;
                        usuario.Email = item.Email;
                        usuario.Imagen = item.Imagen;

                        usuario.NombreCompleto = $"{item.Nombre} {item.ApellidoPaterno} {item.ApellidoMaterno}";

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = item.IdRol.Value;

                        usuario.Direccion = new ML.Direccion();
                        usuario.Direccion.IdDireccion = item.IdDireccion;
                        usuario.Direccion.Calle = item.Calle;
                        usuario.Direccion.NumeroInterior = item.NumeroInterior;
                        usuario.Direccion.NumeroExterior = item.NumeroExterior;

                        usuario.Direccion.Colonia = new ML.Colonia();
                        usuario.Direccion.Colonia.IdColonia = item.IdColonia.Value;
                        usuario.Direccion.Colonia.Nombre = item.NombreColonia;
                        usuario.Direccion.Colonia.CodigoPostal = item.CodigoPostal;

                        usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuario.Direccion.Colonia.Municipio.IdMunicipio = item.IdMunicipio.Value;
                        usuario.Direccion.Colonia.Municipio.Nombre = item.NombreMunicipio;

                        usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuario.Direccion.Colonia.Municipio.Estado.IdEstado = item.IdEstado.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Nombre = item.NombreEstado;

                        usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais = item.IdPais.Value;
                        usuario.Direccion.Colonia.Municipio.Estado.Pais.Nombre = item.NombrePais;

                        result.Objeto = usuario;
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

        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.UsuarioUpdate(usuario.IdUsuario,usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Sexo.ToString(), usuario.FechaNacimiento, usuario.Password, usuario.Telefono, usuario.Celular, usuario.CURP, usuario.UserName, usuario.Email, usuario.Rol.IdRol,null, usuario.Direccion.Calle, usuario.Direccion.NumeroInterior, usuario.Direccion.NumeroExterior, usuario.Direccion.Colonia.IdColonia);

                    if (query > 0)
                    {
                        result.Message = "Se actualizo el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result DeleteEF(byte idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    int query = context.UsuarioDelete(idUsuario);

                    if (query > 0)
                    {
                        result.Message = "Se elimino el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        //LINQ

        public static ML.Result AddLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    DL_EF.Usuario usuarioDL = new DL_EF.Usuario();

                    usuarioDL.Nombre = usuario.Nombre;
                    usuarioDL.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioDL.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioDL.Sexo = usuario.Sexo.ToString();
                    usuarioDL.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento.ToString());
                    usuarioDL.Password = usuario.Password;
                    usuarioDL.Telefono = usuario.Telefono;
                    usuarioDL.Celular = usuario.Celular;
                    usuarioDL.CURP = usuario.CURP;
                    usuarioDL.UserName = usuario.UserName;
                    usuarioDL.Email = usuario.Email;

                    usuarioDL.IdRol = usuario.Rol.IdRol;

                    context.Usuarios.Add(usuarioDL);
                    int resp = context.SaveChanges();

                    if(resp > 0)
                    {
                        result.Message = "Se agrego el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al insertar el usuario" + result.Ex;

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
                    var query = (from usuarioLINQ in context.Usuarios select new { IdUsuario = usuarioLINQ.IdUsuario, Nombre = usuarioLINQ.Nombre, ApellidoPaterno = usuarioLINQ.ApellidoMaterno, ApellidoMaterno = usuarioLINQ.ApellidoMaterno, Sexo = usuarioLINQ.Sexo, 
                        FechaNacimiento = usuarioLINQ.FechaNacimiento, Password = usuarioLINQ.Password, Telefono = usuarioLINQ.Telefono, Celular = usuarioLINQ.Celular, CURP = usuarioLINQ.CURP, UserName = usuarioLINQ.UserName, Email = usuarioLINQ.Email, IdRol = usuarioLINQ.IdRol});

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Sexo = char.Parse(item.Sexo.ToString().Trim());
                            usuario.FechaNacimiento = item.FechaNacimiento.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture);
                            usuario.Password = item.Password;
                            usuario.Telefono = item.Telefono;
                            usuario.Celular = item.Celular;
                            usuario.CURP = item.CURP;
                            usuario.UserName = item.UserName;
                            usuario.Email = item.Email;

                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = item.IdRol.Value;

                            result.Objects.Add(usuario);
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

        public static ML.Result GetByIdLINQ(byte idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from usuarioLINQ in context.Usuarios where usuarioLINQ.IdUsuario == idUsuario select new { IdUsuario = usuarioLINQ.IdUsuario, Nombre = usuarioLINQ.Nombre, ApellidoPaterno = usuarioLINQ.ApellidoMaterno, ApellidoMaterno = usuarioLINQ.ApellidoMaterno, Sexo = usuarioLINQ.Sexo, 
                        FechaNacimiento = usuarioLINQ.FechaNacimiento, Password = usuarioLINQ.Password, Telefono = usuarioLINQ.Telefono, Celular = usuarioLINQ.Celular, CURP = usuarioLINQ.CURP, UserName = usuarioLINQ.UserName, Email = usuarioLINQ.Email, IdRol = usuarioLINQ.IdRol}).SingleOrDefault();

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Sexo = char.Parse(query.Sexo.ToString().Trim());
                        usuario.FechaNacimiento = query.FechaNacimiento.ToString("dd/mm/yyyy", CultureInfo.InvariantCulture);
                        usuario.Password = query.Password;
                        usuario.Telefono = query.Telefono;
                        usuario.Celular = query.Celular;
                        usuario.CURP = query.CURP;
                        usuario.UserName = query.UserName;
                        usuario.Email = query.Email;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = query.IdRol.Value;

                        result.Objeto = usuario;
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

        public static ML.Result UpdateLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios where Usuario.IdUsuario == usuario.IdUsuario select Usuario).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = usuario.Nombre;
                        query.ApellidoPaterno = usuario.ApellidoPaterno;
                        query.ApellidoMaterno = usuario.ApellidoMaterno;
                        query.Sexo = usuario.Sexo.ToString();
                        query.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento.ToString());
                        query.Password = usuario.Password;
                        query.Telefono = usuario.Telefono;
                        query.Celular = usuario.Celular;
                        query.CURP = usuario.CURP;
                        query.UserName = usuario.UserName;
                        query.Email = usuario.Email;

                        query.IdRol = usuario.Rol.IdRol;
                        context.SaveChanges();
                        result.Message = "Se actualizo el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result DeleteLINQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = (from Usuario in context.Usuarios where Usuario.IdUsuario == usuario.IdUsuario select Usuario).SingleOrDefault(); ;

                    context.Usuarios.Remove(query);
                    int resp = context.SaveChanges();
                    if (resp > 0)
                    {
                        result.Message = "Se elimino el usuario correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al eliminar el usuario" + result.Ex;

                throw;
            }
            return result;
        }

        public static ML.Result ChangeStatus(byte idUsuario, bool status)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.EYañezProgramacionNCapasEntities context = new DL_EF.EYañezProgramacionNCapasEntities())
                {
                    var query = context.UsuarioChangeStatus(idUsuario,status);

                    if (query > 0)
                    {
                        result.Message = "Se actualizo el status correctamente";
                    }
                }
                result.Correct = true;
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.Message = "Ocurrio un error al actualizar el status" + result.Ex;
            }
            return result;
        }
    }
}
