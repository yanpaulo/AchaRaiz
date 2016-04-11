using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiz
{
    public class FuncaoTexto : Funcao
    {
        private string texto;

        public FuncaoTexto(string texto)
        {
            this.texto = texto;
        }
        
        public override double Em(double x)
        {
            Expression ex = new Expression(texto.Replace("x", (x.ToString().Replace(",", "."))));
            return (double)ex.Evaluate();
        }

        public override Func<double, double> AsDelegate()
        {
            return (x) => this.Em(x);
        }
    }
}
