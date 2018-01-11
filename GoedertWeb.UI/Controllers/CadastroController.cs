using GoedertWeb.UI.Models;
using System.Web.Configuration;
using System.Web.Mvc;

namespace GoedertWeb.UI.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            return View();
        }

        public ActionResult TelaCrud(string acao)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            ViewBag.IND_ACAO = acao;

            DadosPessoas model = new DadosPessoas();

            model.id_tipo_pessoa = "";
            model.sexo = "";

            return PartialView("_partialCrud", model);
        }

        public ActionResult WebCam(string acao)
        {
            ViewBag.WEB_API = WebConfigurationManager.AppSettings["WEB_API"];
            ViewBag.ACAO = acao;

            DadosPessoas model = new DadosPessoas();

            return PartialView("_webCam", model);
        }
    }
}