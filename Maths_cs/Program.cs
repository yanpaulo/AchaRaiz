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
            string texto = string.Empty;
            if (args.Length > 0)
            {
                texto = args[0];
            }
            else
            {
                texto = Console.ReadLine();
            }
            if (string.IsNullOrWhiteSpace(texto))
            {
                texto = "Pow(x, 2) + 2*x";
            }

            IFuncao f = new FuncaoTexto(texto);
            try
            {
                AchaRaiz ar = new AchaRaiz(f);

                double epsilon = 1e-5;
                string saida = "" +
                $"Bissecão:\n\t {ar.Bisseccao(-3, -1, epsilon)}\n" +
                $"MPF:\n\t {ar.MPF(-3, -1, epsilon, epsilon)}\n" +
                $"MPF2:\n\t {ar.MPF2(-1.5, 0.1, 0.1)}\n" +
                $"Raphson:\n\t {ar.Raphson(-3, epsilon, epsilon)}\n" +
                $"Secante:\n\t {ar.Secante(-3, -1, epsilon, epsilon)}\n";

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
