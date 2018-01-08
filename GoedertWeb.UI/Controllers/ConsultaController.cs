using GoedertWeb.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GoedertWeb.UI.Controllers
{
    public class ConsultaController : Controller
    {
        // GET: Consulta
        public ActionResult Index()
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            return View();
        }

        [HttpPost]
        public ActionResult ResumoConsulta(List<DadosPessoas> model)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];

            foreach (var dadosPessoa in model)
            {                
                switch (dadosPessoa.id_tipo_pessoa)
                {
                    case "2":
                        dadosPessoa.descricao = "Funcionário";
                        break;
                    case "3":
                        dadosPessoa.descricao = "Prestador de Serviço";
                        break;
                    case "4":
                        dadosPessoa.descricao = "Visitante";
                        break;
                    default:
                        dadosPessoa.descricao = "Morador";
                        break;
                }

                var imagem = Convert.ToBase64String(dadosPessoa.foto);

                if (imagem.Equals("QEA=") ||imagem.Equals("AA==") || String.IsNullOrEmpty(imagem))
                {
                    dadosPessoa.foto_string = null;
                    dadosPessoa.foto = null;
                }
                else
                {
                    dadosPessoa.foto_string = String.Format("data:image/png;base64,{0}", imagem);
                    dadosPessoa.foto = null;
                }
            }
            
            return PartialView("_resumoConsulta", model);
        }

        [HttpPost]
        public ActionResult TelaCrud(string idPessoa, List<DadosPessoas> dadosPessoas)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];

            var model = dadosPessoas.Where(t => t.id_pessoa == idPessoa).SingleOrDefault();

            return PartialView("_partialCrud", model);
        }
        
        [HttpPost]
        public ActionResult WebCam(string acao, string idPessoa, List<DadosPessoas> dadosPessoas)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            ViewBag.ACAO = acao;

            var model = dadosPessoas.Where(t => t.id_pessoa == idPessoa).SingleOrDefault();

            return PartialView("_webCam", model);
        }
    }
}