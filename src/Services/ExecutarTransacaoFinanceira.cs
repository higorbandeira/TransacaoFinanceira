using System;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories.interfaces;
using TransacaoFinanceira.Services.interfaces;

namespace TransacaoFinanceira.Services
{
    public class ExecutarTransacaoFinanceira : IExecutarTransacaoFinanceira
    {
        private IAcessoDados _acessoDados;

        public ExecutarTransacaoFinanceira(IAcessoDados acessoDados)
        {
            _acessoDados = acessoDados;
        }

        public void ProcessarTransacoes(Transacao[] transacoes)
        {
            foreach (var item in transacoes)
            {
                Transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.Valor);
            }
        }

        private void Transferir(int correlation_id, uint conta_origem, uint conta_destino, decimal valor)
        {
            ContasSaldo conta_saldo_origem = _acessoDados.GetContasSaldo(conta_origem);
            if (conta_saldo_origem.Saldo < valor)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", correlation_id);
            }
            else
            {
                ContasSaldo conta_saldo_destino = _acessoDados.GetContasSaldo(conta_destino);
                conta_saldo_origem.Debitar(valor);
                conta_saldo_destino.Creditar(valor);
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlation_id, conta_saldo_origem.Saldo, conta_saldo_destino.Saldo);
            }
        }


    }
}
