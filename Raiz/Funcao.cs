using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiz
{
    public abstract class Funcao : IFuncao
    {

        public abstract double Em(double x);

        public double DerivadaEm(double x)
        {
            double delta = 1.0e-6;
            double x1 = x - delta;
            double x2 = x + delta;
            double y1 = this.Em(x1);
            double y2 = this.Em(x2);
            return (y2 - y1) / (x2 - x1);
        }

        public IFuncao Derivada()
        {
            return new FuncaoDelegate(x => this.DerivadaEm(x));
        }

        public abstract Func<double, double> AsDelegate();

        
    }
}
