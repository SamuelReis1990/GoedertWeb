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

            model = model ?? new List<DadosPessoas>();

            if (model.Count > 0)
            {
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

                    if (dadosPessoa.foto != null)
                    {
                        var imagem = Convert.ToBase64String(dadosPessoa.foto);

                        if (imagem.Equals("QEA=") || imagem.Equals("AA==") || String.IsNullOrEmpty(imagem))
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

                    if (!String.IsNullOrEmpty(dadosPessoa.dt_ini_val))
                    {
                        dadosPessoa.dt_ini_val = dadosPessoa.dt_ini_val.Replace("T00:00:00", "");
                        string[] dt_ini_val = dadosPessoa.dt_ini_val.Split('-');
                        dadosPessoa.dt_ini_val = dt_ini_val[2] + '/' + dt_ini_val[1] + '/' + dt_ini_val[0];
                    }

                    if (!String.IsNullOrEmpty(dadosPessoa.dt_fim_val))
                    {
                        dadosPessoa.dt_fim_val = dadosPessoa.dt_fim_val.Replace("T00:00:00", "");
                        string[] dt_fim_val = dadosPessoa.dt_fim_val.Split('-');
                        dadosPessoa.dt_fim_val = dt_fim_val[2] + '/' + dt_fim_val[1] + '/' + dt_fim_val[0];
                    }
                }
            }

           return PartialView("_resumoConsulta", model);
        }

        [HttpPost]
        public ActionResult TelaCrud(string acao, string idPessoa, List<DadosPessoas> dadosPessoas)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            ViewBag.IND_ACAO = acao;

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