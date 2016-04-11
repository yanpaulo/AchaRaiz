using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiz
{
    public class FuncaoDelegate : Funcao
    {
        private Func<double, double> f;


        public FuncaoDelegate(Func<double, double> f)
        {
            this.f = f;
        }
        
        public override double Em(double x)
        {
            return f(x);
        }

        public override Func<double, double> AsDelegate()
        {
            return f;
        }
    }
}
