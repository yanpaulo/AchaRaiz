using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Raiz.WebApp.Models
{
    public class DadosSaida
    {
        public string Nome { get; set; }

        public AchaRaizesResult Result { get; set; }

        [DisplayName("Tempo(ms)")]
        public long TimeMilisseconds { get; set; }

        [DisplayName("Ticks")]
        public long TimeTicks { get; set; }

        public bool Erro { get; set; }

        public string MensagemErro { get; set; }
    }
}