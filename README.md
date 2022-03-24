
# Desafio Toro Desenvolvedor Full-Stack e Backend

Api Restful feita em .Net SDK 5.0.404, em camadas, usando Entity framework para persistencia e acesso ao banco de dados,
Swagger para documentação da Api e SQLServer como SGBD.
Front-End utilizando Angular 13.2.4


## Pré requisitos
 
1. [Node.js - Recommended For Most Users](https://nodejs.org/en/download/)
2. [Visual Code](https://code.visualstudio.com/download)
3. [Angular](https://angular.io/guide/setup-local)
4. [Visual Studio 2019](https://visualstudio.microsoft.com/pt-br/vs/)

## Como baixar o código

git clone https://github.com/JucelioAmaral/InvestimentosEmAcoes.git

OBS: Projeto também pode ser encontrado no endereço: https://gitlab.com/JucelioAmaral/testetr/-/tree/master

## Como configurar a api(Backend)?

1. Abrir a Visual Code ou Studio;
2. Configurar o arquivo "appsettings.Development.json" com a connectionString, apontando para o banco SQL server;
3. Instalar o pacote do sql server: "Install-Package Microsoft.EntityFrameworkCore.SqlServer";
4. Instalar o pacote Install-Package Microsoft.EntityFrameworkCore.InMemory -Version 3.1.5, seguindo o item 4 abaixo porém, alterar o "Default project" para "DesafioToro.Tests"
5. Abrir o Package Manager Console, alterar o "Default project" (que fica na parte superior do console) para o Class Library que encontra-se os arquivos de persistência para "DesafioToro.Persistence"
6. Executar o comando: Add-Migration InitialCreate;
7. Executar o comando: Update-Database;
8. Executar a api (DesafioToro).

**API roda na porta 5001 e pode ser testada pelo link: https://localhost:5001/swagger/index.html**

## Como executar o app (Frontend)?

1. Abrir o Console/Terminal do Visual Code e entrar no diretório do app;
2. Instalar os pacotes do projeto usandoo comando: npm install;
3. Instalar o Angular, versão 13.2.4 usando o comando: npm install -g @angular/cli@13.2.4;
4. Execute ao comando: npm start ou ng serve-o;
5. Caso não abra, acesso a página Angula usando o link: http://localhost:4200/
