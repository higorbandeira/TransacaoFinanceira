# TransacaoFinanceira

Case para refatoração



Passos a implementar:



1. Corrija o que for necessario para resolver os erros de compilação.
   Criaçao de um objeto para normalizar os dados de entrada. Um registro do tipo uint encontrado, normalizei todos os tipo para o mesmo uint.
   
2. Execute o programa para avaliar a saida, identifique e corrija o motivo de algumas transacoes estarem sendo canceladas mesmo com saldo positivo e outras sem saldo sendo efetivadas.
   Foi ajustado o indice do texto que informa a efetivação da transação. Também foi removido o foreach paralelo por um sincrono, para evitar erro na sequencia de transações de mesma origem.
   
3. Aplique o code review e refatore conforme as melhores praticas(SOLID,Patterns,etc).
   Aplicado o principio da responsabilidade unica, interfaces segregadas, injecao de dependencias, inversao de controle, padrao repositorio, padrao fabrica.
   
4. Implemente os testes unitários que julgar efetivo.
    Testes unitários criados apenas para métodos que processam e acessam dados.
   
5. Crie um git hub e compartilhe o link respondendo o ultimo e-mail.

Obs: Voce é livre para implementar na linguagem de sua preferência desde que respeite as funcionalidades e saídas existentes, além de aplicar os conceitos solicitados.

