using NCalc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;
namespace Raiz
{
    class Program
    {
        static void Main(string[] args)
        {
            IFuncao f = new FuncaoDelegate(x => Pow(x, 2) + 2 * x);
            double a = -3, b = -1;
            double x0 = -1.5, x1 = -1;
            double e0 = 1e-5, e1 = 1e-5;
            int k = 1000;
            #region Leitura de Parâmetros
            try
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    //Segundo caractere de cada argumento. Ex.:
                    //-f, segundo caractede: f
                    char p = args[i][1];
                    string value = args[i + 1];
                    switch (p)
                    {
                        case 'f':
                            f = new FuncaoTexto(value);
                            break;
                        case 'i':
                            var iStrings = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            a = double.Parse(iStrings[0]);
                            b = double.Parse(iStrings[1]);
                            break;
                        case 'x':
                            var xStrings = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            x0 = double.Parse(xStrings[0]);
                            x1 = double.Parse(xStrings[1]);
                            break;
                        case 'e':
                            var eStrings = value.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            e0 = double.Parse(eStrings[0]);
                            e1 = double.Parse(eStrings[1]);
                            break;
                        case 'k':
                            k = int.Parse(value);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Entrada inválida.");
                return;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Entrada inválida.");
                return;
            }
            #endregion


            #region "Validação" da função
            try
            {
                //Gambiarra pra testar se a função é válida
                string obj = f.Em(a).ToString();
                obj = f.Em(x0).ToString();
            }
            catch (Exception)
            {
                Console.WriteLine("Função inválida.");
                return;
            }
            #endregion


            AchaRaiz ar = new AchaRaiz(f, k);

            Avalia("Bissecão", () => ar.Bisseccao(a, b, e0));
            Avalia("Posição Falsa", () => ar.MPF(a, b, e0, e1));
            Avalia("Posição Fixa (Prato Feito)", () => ar.MPF2(x0, e0, e1));
            Avalia("Raphson", () => ar.Raphson(x0, e0, e1));
            Avalia("Raphson", () => ar.Secante(x0, x1, e0, e1));
            
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Console.ReadKey();
            }
        }

        static void Avalia(string nome, Func<AchaRaizesResult> metodo)
        {
            Stopwatch sw = new Stopwatch();
            try
            {
                sw.Start();
                var res = metodo.Invoke();
                sw.Stop();
                Console.WriteLine($"{nome}:\n\t {res}, {sw.ElapsedMilliseconds}ms, {sw.ElapsedTicks} ticks\n");
            }
            catch (Exception)
            {
                var color = Console.BackgroundColor;
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nErro em {nome}.\n\n");
                Console.BackgroundColor = color;
            }
        }


    }




}
