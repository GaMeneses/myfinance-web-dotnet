# myfinance-web-dotnet
MyFinance - Projeto do curso de Pós-Graduação em Engenharia de Software PUC-MG. 

Projeto de trabalho da disciplina Práticas de Implementação e Evolução de Software da Especialização em Engenharia de Software da PUC-MG.

Integrantes:

    Lucas Morio da Cruz
    Gabriel Meneses Costa Curta


## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads), [SQL Server Management](https://aka.ms/ssmsfullsetup). 
Além disto, a IDE utilizada no projeto foi [VisualStudio](https://visualstudio.microsoft.com/pt-br/downloads/)

### 🎲 Configurando o projeto

1. Clone este repositório
```bash
$ git clone https://github.com/GaMeneses/myfinance-web-dotnet/
```

2. Restaure as dependências do projeto

![image](https://github.com/GaMeneses/myfinance-web-dotnet/assets/125907237/27d50ffd-c0d9-4644-8fa1-24736b0fed81)

### 🎲 Criando o banco de dados
Para este projeto, usamos o recurso do próprio framework para a criação do database e das tabelas.

1. Em primeiro lugar, verifique se os dados da string de conexão estão corretas no arquivo <b>appsettings.json</b>:

![image](https://github.com/GaMeneses/myfinance-web-dotnet/assets/125907237/782495e9-0c85-454e-80b5-8aa812cc0c31)

2. Em seguida, abra o console do próprio Visual Studio. Caso não esteja aparecendo na parte inferior do seu Visual Studio, realize o seguinte passo:

```bash
Tools -> NuGet Package Manager -> Package Manager Console
```

3. Execute a seguinte linha de comando no console:

```bash
Add-Migration Initial-Migration
```

4. Após a criação do migration, execute a linha de comando abaixo:

```bash
Update-Database Initial-Migration
```

### 🎲 Rodando o projeto
Ainda no console, execute o comando abaixar para rodar o projeto. Após o termino do build, abra o browser no endereço: http://localhost:5247/

```bash
dotnet run --project myfinance-web-dotnet
```

Ou para `buildar` o projeto e restaurar suas dependências:

```bash
dotnet watch --project myfinance-web-dotnet
```
   


