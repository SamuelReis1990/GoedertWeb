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
    }
}