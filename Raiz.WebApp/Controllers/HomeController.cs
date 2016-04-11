using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raiz.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string expression, double a = -1, double b = -1)
        {
            try
            {
                AchaRaiz ar = new AchaRaiz(new FuncaoTexto(expression));
                double epsilon = 1e-5;
                string saida = "" +
                $"Bisseccao: {ar.Bisseccao(-3, -1, epsilon)}\n" +
                $"MPF: {ar.MPF(-3, -1, epsilon, epsilon)}\n" +
                $"MPF2: {ar.MPF2(-1.5, 0.1, 0.1)}\n" +
                $"Raphson: {ar.Raphson(-3, epsilon, epsilon)}\n" +
                $"Secante: {ar.Secante(-3, -1, epsilon, epsilon)}\n";
                ViewBag.Saida = saida.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (EvaluationException)
            {
                ModelState.AddModelError("expression", "Função inválida");
            }
            return View();

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}