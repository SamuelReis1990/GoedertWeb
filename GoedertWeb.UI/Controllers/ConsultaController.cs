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
            return View();
        }

        [HttpPost]
        public ActionResult ResumoConsulta(List<DadosPessoas> model, string viewCadastro = "N", string tipoPesquisa = "")
        {
            ViewBag.VIEW_CADASTRO = viewCadastro;
            ViewBag.TIPO_PESQUISA = tipoPesquisa;

            model = model ?? new List<DadosPessoas>();            

            if (model.Count > 0)
            {
                foreach (var dadosPessoa in model)
                {                    
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

                    if (dadosPessoa.dadosDocumentos.Count > 0)
                    {
                        foreach (var dadosDocumento in dadosPessoa.dadosDocumentos)
                        {
                            if (!String.IsNullOrEmpty(dadosDocumento.numero) && !String.IsNullOrEmpty(dadosDocumento.descricao))
                            {
                                dadosDocumento.descricao += " " + dadosDocumento.numero;
                            }
                            else
                            {
                                dadosDocumento.descricao = "";
                                dadosDocumento.numero = "";
                            }
                        }
                    }
                }
            }

           return PartialView(model);
        }

        [HttpPost]
        public ActionResult TelaCrud(string acao, string idPessoa, List<DadosPessoas> dadosPessoas)
        {
            ViewBag.IND_ACAO = acao;

            var model = dadosPessoas.Where(t => t.id_pessoa == idPessoa).SingleOrDefault();

            return PartialView("_partialCrud", model);
        }
        
        [HttpPost]
        public ActionResult WebCam(string acao, string idPessoa, List<DadosPessoas> dadosPessoas, string viewCadastro = "N", string tipoPesquisa = "")
        {
            ViewBag.ACAO = acao;
            ViewBag.VIEW_CADASTRO = viewCadastro;
            ViewBag.TIPO_PESQUISA = tipoPesquisa;

            var model = dadosPessoas.Where(t => t.id_pessoa == idPessoa).SingleOrDefault();

            return PartialView("_webCam", model);
        }
    }
}