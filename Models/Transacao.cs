using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Models
{
    public class Transacao
    {
        public int CorrelationId { get; set; }
        public DateTime Datetime { get; set; }
        public uint ContaOrigem { get; set; }
        public uint ContaDestino { get; set; }
        public decimal Valor { get; set; }

        public Transacao(int correlationId,
            string datetime,
            uint contaOrigem,
            uint contaDestino,
            decimal valor)
        {
            this.CorrelationId = correlationId;
            this.Datetime = Convert.ToDateTime(datetime);
            this.ContaOrigem = contaOrigem;
            this.ContaDestino = contaDestino;
            this.Valor = valor;
        }
    }
}
