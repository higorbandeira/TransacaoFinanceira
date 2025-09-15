using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories;
using TransacaoFinanceira.Repositories.interfaces;
using TransacaoFinanceira.Services;
using TransacaoFinanceira.Services.interfaces;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {
        private static IAcessoDados _acessoDados = new AcessoDados();
        private static IExecutarTransacaoFinanceira _executarTransacaoFinanceira = new ExecutarTransacaoFinanceira(_acessoDados);

        static void Main(string[] args)
        {
            Transacao[] transacoes = _acessoDados.GetTransacoes();
            _executarTransacaoFinanceira.ProcessarTransacoes(transacoes);
        }
    }
}
