using GoedertWeb.UI.Models;
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
    }
}