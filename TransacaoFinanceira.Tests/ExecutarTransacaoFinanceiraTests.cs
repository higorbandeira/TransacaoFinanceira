using Moq;
using TransacaoFinanceira.Models;
using TransacaoFinanceira.Repositories.interfaces;
using TransacaoFinanceira.Services;

namespace TransacaoFinanceira.Tests
{
    public class ExecutarTransacaoFinanceiraTests
    {
        private readonly Mock<IAcessoDados> _mockAcessoDados;
        private readonly ExecutarTransacaoFinanceira _executor;

        public ExecutarTransacaoFinanceiraTests()
        {
            _mockAcessoDados = new Mock<IAcessoDados>();
            _executor = new ExecutarTransacaoFinanceira(_mockAcessoDados.Object);
        }

        [Fact]
        public void transferir_SaldoSuficiente_DeveEfetivarTransacao()
        {
            // Arrange
            var correlationId = 1;
            string dataHora = "09/09/2023 14:15:00";
            uint contaOrigem = 938485762;
            uint contaDestino = 2147483649;
            decimal valor = 100;

            var contaOrigemObj = new ContasSaldo(contaOrigem, 180);
            var contaDestinoObj = new ContasSaldo(contaDestino, 0);
            var transacoes = new Transacao[] { new Transacao(1, dataHora, contaOrigem, contaDestino, valor) };

            _mockAcessoDados.Setup(a => a.GetContasSaldo(contaOrigem)).Returns(contaOrigemObj);
            _mockAcessoDados.Setup(a => a.GetContasSaldo(contaDestino)).Returns(contaDestinoObj);

            // Act
            _executor.ProcessarTransacoes(transacoes);

            // Assert
            Assert.Equal(80, contaOrigemObj.Saldo);
            Assert.Equal(100, contaDestinoObj.Saldo);
        }

        [Fact]
        public void transferir_SaldoInsuficiente_DeveCancelarTransacao()
        {
            // Arrange
            var correlationId = 1;
            string dataHora = "09/09/2023 14:15:00";
            uint contaOrigem = 938485762;
            uint contaDestino = 2147483649;
            decimal valor = 200;

            var contaOrigemObj = new ContasSaldo(contaOrigem, 180);
            var contaDestinoObj = new ContasSaldo(contaDestino, 0);
            var transacoes = new Transacao[] { new Transacao(1, dataHora, contaOrigem, contaDestino, valor) };

            _mockAcessoDados.Setup(a => a.GetContasSaldo(contaOrigem)).Returns(contaOrigemObj);
            _mockAcessoDados.Setup(a => a.GetContasSaldo(contaDestino)).Returns(contaDestinoObj);

            // Act
            _executor.ProcessarTransacoes(transacoes);

            // Assert
            Assert.Equal(180, contaOrigemObj.Saldo);
            Assert.Equal(0, contaDestinoObj.Saldo);
        }
    }
}