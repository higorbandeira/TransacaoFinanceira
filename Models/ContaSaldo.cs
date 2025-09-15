using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransacaoFinanceira.Models
{
    public class ContasSaldo
    {
        public ContasSaldo(uint conta, decimal valor)
        {
            this.Conta = conta;
            this.Saldo = valor;
        }
        public uint Conta { get; set; }
        public decimal Saldo { get; set; }
    }
}
