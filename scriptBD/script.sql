USE [myfinanceweb]
GO
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
