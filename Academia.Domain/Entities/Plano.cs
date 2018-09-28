using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academia.Domain.Entities
{
    public class Plano
    {
        public int PlanoId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int PeriodoMeses { get; set; }
        
        public decimal Valor { get; set; }    

    }
}
