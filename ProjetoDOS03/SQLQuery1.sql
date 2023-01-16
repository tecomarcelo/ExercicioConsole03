﻿CREATE TABLE PRODUTO(
	IDPRODUTO	UNIQUEIDENTIFIER	NOT NULL,
	NOME		NVARCHAR(150)		NOT NULL,
	PRECO		DECIMAL				NOT NULL,
	QUANTIDADE	INT					NOT NULL,
	DATACOMPRA	DATETIME			NOT NULL,

	PRIMARY KEY(IDPRODUTO))
GO