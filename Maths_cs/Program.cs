using NCalc;
using System;
using System.Collections.Generic;
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
                        x0 = double.Parse(eStrings[0]);
                        x1 = double.Parse(eStrings[1]);
                        break;
                    case 'k':
                        k = int.Parse(value);
                        break;
                    default:
                        break;
                }
            }

            try
            {
                AchaRaiz ar = new AchaRaiz(f);
                
                string saida = "" +
                $"Bissecão:\n\t {ar.Bisseccao(a, b, e0)}\n" +
                $"MPF:\n\t {ar.MPF(a, b, e0, e1)}\n" +
                $"MPF2:\n\t {ar.MPF2(x0, e0, e1)}\n" +
                $"Raphson:\n\t {ar.Raphson(x0, e0, e1)}\n" +
                $"Secante:\n\t {ar.Secante(x0, x1, e0, e1)}\n";

                Console.WriteLine(saida);
            }
            catch (EvaluationException)
            {
                Console.WriteLine("Entrada inválida!!");
            }


            Console.ReadKey();
        }


    }




}
