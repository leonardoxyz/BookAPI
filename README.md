# BookAPI - Web API em C#

Bem-vindo ao projeto BookAPI! Esta é uma API poderosa que permite criar, gerenciar e relacionar livros, bibliotecas e endereços de forma eficiente. Com esta API, você pode realizar operações CRUD (criar, ler, atualizar, excluir) em livros, bibliotecas e endereços.

## Iniciando

Siga estas instruções para configurar e executar o projeto em sua própria máquina.

### Pré-requisitos

Antes de começar, certifique-se de ter as seguintes ferramentas instaladas:

- [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)
- [Postman](https://www.postman.com/downloads/)

### Instalação

1. Clone este repositório em sua máquina:
   
2. Abra o projeto em seu Visual Studio.

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`. Certifique-se de que a configuração esteja de acordo com seu ambiente. O projeto usa Entity Framework Core para gerenciar o banco de dados.

4. Abra o Package Manager Console no Visual Studio e execute as migrações para criar o banco de dados:

5. Execute a aplicação.

### Uso

Agora que a aplicação está em execução, você pode começar a usar a API para gerenciar livros, bibliotecas e endereços. Aqui estão algumas das principais rotas disponíveis:

- `GET /book`: Retorna todos os livros cadastrados.
- `GET /book/{id}`: Retorna um livro específico pelo ID.
- `POST /book`: Cria um novo livro.
- `PUT /book/{id}`: Atualiza um livro existente pelo ID.
- `DELETE /book/{id}`: Exclui um livro pelo ID.

- `GET /library`: Retorna todas as bibliotecas cadastradas.
- `GET /library/{id}`: Retorna uma biblioteca específica pelo ID.
- `POST /library`: Cria uma nova biblioteca.
- `PUT /library/{id}`: Atualiza uma biblioteca existente pelo ID.
- `DELETE /library/{id}`: Exclui uma biblioteca pelo ID.

- `GET /address`: Retorna todos os endereços cadastrados.
- `GET /address/{id}`: Retorna um endereço específico pelo ID.
- `POST /address`: Cria um novo endereço.
- `PUT /address/{id}`: Atualiza um endereço existente pelo ID.
- `DELETE /address/{id}`: Exclui um endereço pelo ID.

Certifique-se de usar o Postman ou outra ferramenta semelhante para fazer solicitações à API.

## Licença

Este projeto está licenciado sob a licença MIT. Consulte o arquivo [LICENSE](LICENSE) para obter detalhes.

Aproveite o uso da sua nova BookAPI! 📚🏢🏠
