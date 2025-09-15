using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Repositories.interfaces
{
    public interface IAcessoDados
    {
        T GetSaldo<T>(uint id);
        void Debitar(ContasSaldo destino, decimal valor);
        void Creditar(ContasSaldo destino, decimal valor);
        Transacao[] GetTransacoes();
    }
}
