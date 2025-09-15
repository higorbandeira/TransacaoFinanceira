namespace TransacaoFinanceira.Services.interfaces
{
    public interface IExecutarTransacaoFinanceira
    {
        void ProcessarTransacoes(Models.Transacao[] transacoes);
    }
}
