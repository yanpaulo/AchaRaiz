using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Raiz.WebApp.Models
{
    public class DadosEntrada
    {

        [DisplayName("F(x)")]
        public string F { get; set; }

        public double A { get; set; } = -3;

        public double B { get; set; } = -1;

        public double X0 { get; set; } = -1.5;

        public double X1 { get; set; } = -1;

        public double E0 { get; set; } = 1e-5;

        public double E1 { get; set; } = 1e-5;

        public int K { get; set; } = 1000;
        
    }
}