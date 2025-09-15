using TransacaoFinanceira.Repositories;

namespace TransacaoFinanceira.Tests
{
    public class AcessoDadosTests
    {
        [Fact]
        public void getSaldo_ContaExistente_DeveRetornarConta()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            uint contaExistente = 938485762;

            // Act
            var resultado = acessoDados.GetContasSaldo(contaExistente);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(contaExistente, resultado.Conta);
            Assert.Equal(180, resultado.Saldo);
        }

        [Fact]
        public void getSaldo_ContaNaoExistente_DeveRetornarNull()
        {
            // Arrange
            var acessoDados = new AcessoDados();
            uint contaNaoExistente = 999999999;

            // Act
            var resultado = acessoDados.GetContasSaldo(contaNaoExistente);

            // Assert
            Assert.Null(resultado);
        }
    }
}