using System;
using System.Collections.Generic;
using System.Threading.Tasks;


//Obs: Voce é livre para implementar na linguagem de sua preferência, desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

namespace TransacaoFinanceira
{
    class Program
    {

        static void Main(string[] args)
        {
            Transacao[] TRANSACOES = new Transacao[] {  
                new Transacao (1,"09/09/2023 14:15:00", 938485762, 2147483649, 150),
                new Transacao (2,"09/09/2023 14:15:05", 2147483649, 210385733, 149),
                new Transacao (3,"09/09/2023 14:15:29", 347586970, 238596054, 1100),
                new Transacao (4,"09/09/2023 14:17:00", 675869708, 210385733, 5300),
                new Transacao (5,"09/09/2023 14:18:00", 238596054, 674038564, 1489),
                new Transacao (6,"09/09/2023 14:18:20", 573659065, 563856300, 49),
                new Transacao (7,"09/09/2023 14:19:00", 938485762, 2147483649, 44),
                new Transacao (8,"09/09/2023 14:19:01", 573659065, 675869708, 150)
            };
            executarTransacaoFinanceira executor = new executarTransacaoFinanceira();
            foreach (var item in TRANSACOES)
            {
                executor.transferir(item.CorrelationId, item.ContaOrigem, item.ContaDestino, item.Valor);
            }
        }
    }

    class executarTransacaoFinanceira: acessoDados
    {
        public void transferir(int correlation_id, uint conta_origem, uint conta_destino, decimal valor)
        {
            contas_saldo conta_saldo_origem = getSaldo<contas_saldo>(conta_origem) ;
            if (conta_saldo_origem.saldo < valor)
            {
                Console.WriteLine("Transacao numero {0} foi cancelada por falta de saldo", correlation_id);

            }
            else
            {
                contas_saldo conta_saldo_destino = getSaldo<contas_saldo>(conta_destino);
                conta_saldo_origem.saldo -= valor;
                conta_saldo_destino.saldo += valor;
                Console.WriteLine("Transacao numero {0} foi efetivada com sucesso! Novos saldos: Conta Origem:{1} | Conta Destino: {2}", correlation_id, conta_saldo_origem.saldo, conta_saldo_destino.saldo);
            }
        }
    }
    class Transacao
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
    class contas_saldo
    {
        public contas_saldo(uint conta, decimal valor)
        {
            this.conta = conta;
            this.saldo = valor;
        }
        public uint conta { get; set; }
        public decimal saldo { get; set; }
    }
    class acessoDados
    {
        Dictionary<int, decimal> SALDOS { get; set; }
        private List<contas_saldo> TABELA_SALDOS;
        public acessoDados()
        {
            TABELA_SALDOS = new List<contas_saldo>();
            TABELA_SALDOS.Add(new contas_saldo(938485762, 180));
            TABELA_SALDOS.Add(new contas_saldo(347586970, 1200));
            TABELA_SALDOS.Add(new contas_saldo(2147483649, 0));
            TABELA_SALDOS.Add(new contas_saldo(675869708, 4900));
            TABELA_SALDOS.Add(new contas_saldo(238596054, 478));
            TABELA_SALDOS.Add(new contas_saldo(573659065, 787));
            TABELA_SALDOS.Add(new contas_saldo(210385733, 10));
            TABELA_SALDOS.Add(new contas_saldo(674038564, 400));
            TABELA_SALDOS.Add(new contas_saldo(563856300, 1200));


            SALDOS = new Dictionary<int, decimal>();
            this.SALDOS.Add(938485762, 180);
           
        }
        public T getSaldo<T>(uint id)
        {          
            return (T)Convert.ChangeType(TABELA_SALDOS.Find(x => x.conta == id), typeof(T));
        }
        public bool atualizar<T>(T  dado)
        {
            try
            {
                contas_saldo item = (dado as contas_saldo);
                TABELA_SALDOS.RemoveAll(x => x.conta == item.conta);
                TABELA_SALDOS.Add(dado as contas_saldo);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

    }
}
