using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Raiz
{
    /// <summary>
    /// Representa o resultado obtido através de AchaRaizes
    /// </summary>
    public struct AchaRaizesResult
    {
        public double Raiz { get; private set; }
        public int K { get; private set; }
        
        public AchaRaizesResult(double raiz, int k)
        {
            K = k;
            Raiz = raiz;
        }

        public override string ToString()
        {
            return $"{Raiz}, K: {K}";
        }
    }

    public class AchaRaiz
    {
        public IFuncao Funcao { get; private set; }
        private Func<double, double> f, f_;
        private int kMax = 1000;

        public AchaRaiz(IFuncao f)
        {
            Funcao = f;
            this.f = f.AsDelegate();
            this.f_ = f.Derivada().AsDelegate();
        }

        /// <summary>
        /// Encontra uma raíz por bissecção
        /// </summary>
        /// <param name="a">Início do Intervalo</param>
        /// <param name="b">Fim do Intervalo</param>
        /// <param name="epsilon">Precisão</param>
        /// <returns>Raíz ou null</returns>
        public AchaRaizesResult Bisseccao(double a, double b, double epsilon)
        {
            if (b - a < epsilon)
            {
                return new AchaRaizesResult((a + b) / 2.0, 0);
            }
            int k = 1;

            double m = f(a);
            while (k < kMax)
            {
                double x = (a + b) / 2.0;
                if (m * f(x) > 0)
                {
                    a = x;
                }
                else
                {
                    b = x;
                }
                if (b - a < epsilon)
                {
                    return new AchaRaizesResult((a + b) / 2.0, k);
                }
                k++;
            }

            return new AchaRaizesResult((a + b) / 2.0, k);
        }

        /// <summary>
        /// Método do Prato Feito
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="e1"></param>
        /// <param name="e2"></param>
        /// <returns></returns>
        public AchaRaizesResult MPF(double a, double b, double e1, double e2)
        {
            //2
            if (b - a < e1)
            {
                return new AchaRaizesResult((a + b) / 2.0, 0);
            }
            if (Abs(f(a)) < e2 || Abs(f(b)) < e2)
            {
                return new AchaRaizesResult(a, 0);
            }
            //3
            int k = 1;
            //4
            double M = f(a);
            while (k < kMax)
            {
                //5
                double x = (a * f(b) - b * f(a)) / (f(b) - f(a));
                //6
                if (Abs(f(x)) < e2)
                {
                    return new AchaRaizesResult(x, k);
                }
                //7
                if (M * f(x) > 0)
                {
                    a = x;
                }
                //8
                else
                {
                    b = x;
                }
                //9
                if (Abs(b - a) < e1)
                {
                    return new AchaRaizesResult((a + b) / 2.0, k);
                }
                //10
                k++;
            }
            return new AchaRaizesResult((a + b) / 2.0, k);
        }

        public AchaRaizesResult MPF2(double x0, double e1, double e2)
        {
            //p(x) = f(x) + x
            Func<double, double> p = (x) => f(x) + x;
            //2
            if (Abs(f(x0)) < e1)
            {
                return new AchaRaizesResult(x0, 0);
            }
            //3
            int k = 1;
            while (k < kMax)
            {
                //4
                double x1 = p(x0);
                //5
                if (Abs(f(x1)) < e1 || Abs(x1 - x0) < e2)
                {
                    return new AchaRaizesResult(x1, k);
                }
                x0 = x1;
                k++; 
            }

            return new AchaRaizesResult(x0, k);
        }

        public AchaRaizesResult Raphson(double x0, double e1, double e2)
        {
            //2
            if (Abs(f(x0)) < e1)
            {
                return new AchaRaizesResult(x0, 0);
            }
            //3
            int k = 1;
            while (k < kMax)
            {
                double em = f(x0), deriv = f_(x0);
                //4
                double x1 = x0 - (f(x0) / f_(x0));
                //5
                if (Abs(f(x1)) < e1 || Abs(x1 - x0) < e2)
                {
                    return new AchaRaizesResult(x1, k);
                }
                //6
                x0 = x1;
                //7
                k++; 
            }

            return new AchaRaizesResult(x0, k);

        }

        public AchaRaizesResult Secante(double x0, double x1, double e1, double e2)
        {
            //2
            if (Abs(f(x0)) < e1)
            {
                return new AchaRaizesResult(x0, 0);
            }
            //3
            if (Abs(f(x1)) < e1 || Abs(x1 - x0) < e2)
            {
                return new AchaRaizesResult(x1, 0);
            }
            //4
            int k = 1;
            while (k < kMax)
            {
                //5
                double x2 = x1 - (f(x1) / (f(x1) - f(x0))) * (x1 - x0);
                //6
                if (Abs(f(x2)) < e1 || Abs(x2 - x1) < e2)
                {
                    return new AchaRaizesResult(x2, k);
                }
                //7
                x0 = x1;
                x1 = x2;
                k++;
            }

            return new AchaRaizesResult(x0, k);
        }
    }
}
