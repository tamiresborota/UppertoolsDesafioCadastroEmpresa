SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Empresa](
	[CNPJ] [varchar](14) NOT NULL,
	[RazaoSocial] [varchar](255) NOT NULL,
	[NomeFantasia] [varchar](255) NOT NULL,
	[SituacaoCadastral] [bit] NOT NULL,
	[Telefone] [varchar](20) NOT NULL,
	[Cidade] [varchar](255) NOT NULL,
	[UF] [varchar](2) NOT NULL,
	[CEP] [varchar](10) NULL,
	[Logradouro] [varchar](255) NOT NULL,
	[Numero] [varchar](20) NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[CNPJ] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


