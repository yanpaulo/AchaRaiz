using NCalc;
using Raiz.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Math;

namespace Raiz.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DadosEntrada dados = new DadosEntrada();
            return View(dados);
        }

        [HttpPost]
        public ActionResult Index(DadosEntrada model)
        {
            if (ModelState.IsValid)
            {
                IFuncao f;
                #region Leitura da função
                if (!string.IsNullOrWhiteSpace(model.F))
                {
                    f = new FuncaoTexto(model.F);
                    #region "Validação" da função
                    try
                    {
                        //Gambiarra pra testar se a função é válida
                        string obj = f.Em(model.A).ToString();
                        obj = f.Em(model.X0).ToString();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("F", "Função inválida.");
                    }
                    #endregion
                }
                else
                {
                    f = new FuncaoDelegate(x => Pow(x, 2) + 2 * x);
                }
                #endregion

                if (ModelState.IsValid)
                {
                    var res = Avalia(model, f);
                    return View("Result", res);
                }

            }

            return View(model);

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        static IEnumerable<DadosSaida> Avalia(DadosEntrada dados, IFuncao f)
        {
            AchaRaiz ar = new AchaRaiz(f, dados.K);

            yield return Avalia("Bissecão", () => ar.Bisseccao(dados.A, dados.B, dados.E0));
            yield return Avalia("Posição Falsa", () => ar.MPF(dados.A, dados.B, dados.E0, dados.E1));
            yield return Avalia("Posição Fixa (Prato Feito)", () => ar.MPF2(dados.X0, dados.E0, dados.E1));
            yield return Avalia("Raphson", () => ar.Raphson(dados.X0, dados.E0, dados.E1));
            yield return Avalia("Secante", () => ar.Secante(dados.X0, dados.X1, dados.E0, dados.E1));

        }

        static DadosSaida Avalia(string nome, Func<AchaRaizesResult> metodo)
        {
            //Nome
            DadosSaida saida = new DadosSaida() { Nome = nome };
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                var res = metodo.Invoke();
                sw.Stop();
                //Resultado
                saida.Result = res;
                saida.TimeMilisseconds = sw.ElapsedMilliseconds;
                saida.TimeTicks = sw.ElapsedTicks;
            }
            catch (Exception)
            {
                //Erro
                saida.MensagemErro = $"Erro em {nome}.";
                saida.Erro = true;
            }

            return saida;
        }
    }
}