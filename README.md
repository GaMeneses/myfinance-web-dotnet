# myfinance-web-dotnet
MyFinance - Projeto do curso de Pós-Graduação em Engenharia de Software PUC-MG. 

Projeto de trabalho da disciplina Práticas de Implementação e Evolução de Software da Especialização em Engenharia de Software da PUC-MG.

Integrantes:

    Lucas Morio da Cruz
    Gabriel Meneses Costa Curta

## Descrição 

Plataforma web que possibilita os usuários registrarem suas receitas e despesas, para que possam ter uma analise de seus gastos e consequentemente desenvolver um melhor planejamento financeiro. A aplicação permite o usuário criar categorias personalizadas para suas transações de despesas e receitas.

## Arquitetura

A arquitetura utilizada no projeto foi MVC (Model-View-Controller) que organiza o software em três componentes principais: Model (Modelo) gerencia os dados, View (Visão) responsável por exibir informações ao usuário e passando as interações para a Controller (Controladora) que processa essas informações e realiza a comunicação com o model e atualizando a view quando necessário.

## Tecnologias

- ASP.NET Core 8.0 EF Core
- SQL Server
- AutoMapper

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads), [SQL Server Management](https://aka.ms/ssmsfullsetup). 
Além disto, a IDE utilizada no projeto foi [VisualStudio](https://visualstudio.microsoft.com/pt-br/downloads/)


### 🎲 Configurando o projeto


1. Clone este repositório

```bash
git clone https://github.com/GaMeneses/myfinance-web-dotnet.git
```

2. Acesse o diretório do projeto

```bash
cd ...\myfinance-web-dotnet\myfinance-web-dotnet\myfinance-web-dotnet
```

### 🎲 Criando o banco de dados
Para este projeto, usamos o recurso do próprio framework para a criação do database e das tabelas.

1. Em primeiro lugar, verifique se os dados da string de conexão estão corretos no arquivo <b>appsettings.json</b>:

![image](https://github.com/GaMeneses/myfinance-web-dotnet/assets/125907237/782495e9-0c85-454e-80b5-8aa812cc0c31)

2. Em seguida, no mesmo diretório execute a seguinte linha de comando no cmd:

```bash
dotnet ef migrations add Initial-Migration
```

3. Após a criação do migration, execute a linha de comando abaixo:

```bash
dotnet ef database update
```

4. Caso preferir rodar o script manualmente ou pegue o script localizado na pasta `scriptBD`:

```bash
/****** Object:  Table [dbo].[PlanoConta]    Script Date: 10/12/2023 16:20:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PlanoConta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [nvarchar](max) NOT NULL,
	[Tipo] [int] NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_PlanoConta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacao]    Script Date: 10/12/2023 16:20:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacao](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Historico] [nvarchar](max) NULL,
	[Tipo] [nvarchar](max) NULL,
	[Valor] [decimal](38, 17) NOT NULL,
	[PlanoContaId] [int] NOT NULL,
	[Data] [datetime2](7) NOT NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_Transacao] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Transacao]  WITH CHECK ADD  CONSTRAINT [FK_Transacao_PlanoConta_PlanoContaId] FOREIGN KEY([PlanoContaId])
REFERENCES [dbo].[PlanoConta] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Transacao] CHECK CONSTRAINT [FK_Transacao_PlanoConta_PlanoContaId]
GO

```


### 🎲 Rodando o projeto
Ainda no mesmo diretório aberto no console, execute o comando abaixo para rodar o projeto. Após o termino do build, abra o browser no endereço: http://localhost:5247/


```bash
dotnet build
dotnet run 
```

Ou para `buildar` o projeto e restaurar suas dependências:

```bash
dotnet watch
```
   


