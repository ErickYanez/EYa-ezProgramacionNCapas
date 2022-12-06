using ML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result resultrol = BL.Rol.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Rol.Roles = resultrol.Objects;
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(usuario);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            ML.Result resultrol = BL.Rol.GetAllEF();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
                usuario.Rol.Roles = resultrol.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(usuario);
        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.GetByIdPais(IdPais);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Form(byte? IdUsuario)
        {
            ML.Result resultrol = BL.Rol.GetAllEF();
            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();

            ML.Result resultpais = BL.Pais.GetAll();
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();

            if (IdUsuario == null)
            {
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;
                usuario.Rol.Roles = resultrol.Objects;
                
                return View(usuario);
            }
            else
            {
                ML.Result result = BL.Usuario.GetByIdEF(IdUsuario.Value);
                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Objeto;
                    usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultpais.Objects;

                    ML.Result resultEstado = BL.Estado.GetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais);
                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado);
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    ML.Result resultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio);
                    usuario.Direccion.Colonia.Colonias = resultColonia.Objects;

                    //usuario.Direccion.Colonia.Municipio.Estado.Estados = (List<object>)GetEstado(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais).Data;
                    //usuario.Direccion.Colonia.Municipio.Municipios = (List<object>)GetMunicipio(usuario.Direccion.Colonia.Municipio.Estado.IdEstado).Data;
                    //usuario.Direccion.Colonia.Colonias = (List<object>)GetColonia(usuario.Direccion.Colonia.Municipio.IdMunicipio).Data;

                    usuario.Rol.Roles = resultrol.Objects;
                    return View(usuario);
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar el usuario";
                }
                return View(usuario);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            //IFormFile image = Request.Form.Files["FileImage"];
            //if (image != null)
            //{
            //    byte[] ImagenBytes = ConvertToBytes(image);
            //    usuario.Imagen = Convert.ToBase64String(ImagenBytes);
            //}
            //if(file.ContentLength>0)
            //{
            //    usuario.Imagen = ConvertToBytes(file);
            //}
            //ADD
            if (usuario.IdUsuario == 0)
            {
                ML.Result result = BL.Usuario.AddEF(usuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }
            else
            {
                //UPDATE
                if (usuario != null)
                {
                    ML.Result result = BL.Usuario.UpdateEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Message = result.Message;
                    }
                    else
                    {
                        ViewBag.Message = "Error: " + result.Message;
                    }
                }
            }
            return PartialView("Modal");
        }

        //[HttpDelete]
        public ActionResult Delete(byte idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            if (usuario != null)
            {
                ML.Result result = BL.Usuario.DeleteEF(idUsuario);
                if (result.Correct)
                {
                    ViewBag.Message = result.Message;
                }
                else
                {
                    ViewBag.Message = "Error: " + result.Message;
                }
            }else
            {
                return Redirect("/Usuario/GetAll");
            }
            return PartialView("Modal");
        }

        //public static byte[] ConvertToBytes(IFormFile imagen)
        //{

        //    using var fileStream = imagen.OpenReadStream();

        //    byte[] bytes = new byte[fileStream.Length];
        //    fileStream.Read(bytes, 0, (int)fileStream.Length);

        //    return bytes;
        //}
        //public byte[] ConvertToBytes(HttpPostedFileBase imagen)
        //{
        //    byte[] data = null;
        //    System.IO.BinaryReader reader = new System.IO.BinaryReader(imagen.InputStream);
        //    data = reader.ReadBytes((int)imagen.ContentLength);
        //    return data;
        //}

        public JsonResult CambiarStatus(byte idUsuario, bool status)
        {
            var result = BL.Usuario.ChangeStatus(idUsuario, status);

            return Json(result.Objects);
        }
    }
}

