using TransacaoFinanceira.Models;

namespace TransacaoFinanceira.Repositories.interfaces
{
    public interface IAcessoDados
    {
        ContasSaldo GetContasSaldo(uint id);
        Transacao[] GetTransacoes();
    }
}
