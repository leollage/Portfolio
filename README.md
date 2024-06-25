1. Controller Products:
  Essa controller gerencia os produtos de investimento.
- Funcionalidades:
  Cadastro de Produto: Adiciona um novo produto ao portfólio.
  Busca de Produto: Encontra um produto existente com base no critério ID.
  Alteração de Produto: Atualiza informações de um produto com base no critério ID.
  Exclusão de Produto: Remove um produto do portfólio com base no critério ID.

2. Controller Client:
  Essa controller lida com as operações relacionadas aos clientes.
- Funcionalidades:
  Cadastro de Cliente: Permite adicionar um novo cliente ao sistema.
  Busca de Cliente: Permite encontrar um cliente existente  com base no critério ID.
  Alteração de Cliente: Permite atualizar informações de um cliente com base no critério ID.
  Exclusão de Cliente: Remove um cliente do sistema com base no critério ID.

3. Controller de Business:
  Essa controller lida com as transações de negócios entre clientes e produtos.
  Para acessar os endpoints da controller, é necessário ter um login de acesso previamente cadastrado no sistema por meio da controller “Client”.
- Funcionalidades:
  Compra de Produto: Permite que um cliente compre um produto de investimento.
  Venda de Produto: Registra a venda de um produto por um cliente.
  Consulta de Produtos Comprados: Exibe os produtos que um cliente comprou.
