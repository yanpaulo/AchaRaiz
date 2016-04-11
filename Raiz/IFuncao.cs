using System;

namespace Raiz
{
    public interface IFuncao
    {
        double Em(double x);
        double DerivadaEm(double x);
        IFuncao Derivada();
        Func<double, double> AsDelegate();
        
    }
}