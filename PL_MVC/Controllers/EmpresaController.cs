using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        [HttpGet]
        public ActionResult GetAll(ML.Empresa empresa)
        {
            ML.Result result = BL.Empresa.GetAllEF(empresa);
            if (result.Correct)
            {
                empresa.Empresas = result.Objects;
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al realizar la consulta";
            }
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Form(int? IdEmpresa)
        {
            ML.Empresa empresa = new ML.Empresa();
            if (IdEmpresa == null)
            {
                return View();
            }
            else
            {
                ML.Result result = BL.Empresa.GetByIdEF(IdEmpresa.Value);
                if (result.Correct)
                {
                    empresa = (ML.Empresa)result.Objeto;
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al buscar el usuario";
                }
                return View(empresa);
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Empresa empresa)
        {
            HttpPostedFileBase file = Request.Files["ImagenData"];

            //if (file.ContentLength > 0)
            //{
            //    empresa.Logo = ConvertToBytes(file);
            //}
            //ADD
            if (empresa.IdEmpresa == 0)
            {
                ML.Result result = BL.Empresa.AddEF(empresa);
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
                if (empresa != null)
                {
                    ML.Result result = BL.Empresa.UpdateEF(empresa);
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
        public ActionResult Delete(ML.Empresa empresa)
        {
            if (empresa != null)
            {
                ML.Result result = BL.Empresa.DeleteEF(empresa);
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
                return Redirect("/Empresa/GetAll");
            }
            return PartialView("Modal");
        }

        public byte[] ConvertToBytes(HttpPostedFileBase logo)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(logo.InputStream);
            data = reader.ReadBytes((int)logo.ContentLength);
            return data;
        }
    }
}