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

        public void Debitar(decimal valor)
        {
            Saldo -= valor;
        }

        public void Creditar(decimal valor)
        {
            Saldo += valor;
        }
    }
}
