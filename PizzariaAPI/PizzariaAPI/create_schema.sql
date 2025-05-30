﻿CREATE TABLE categoria_produto (
    "IdCategoria" integer GENERATED BY DEFAULT AS IDENTITY,
    "NmCategoria" character varying(100) NOT NULL,
    "Descricao" character varying(100) NOT NULL,
    CONSTRAINT "PK_categoria_produto" PRIMARY KEY ("IdCategoria")
);


CREATE TABLE cupom (
    "IdCupom" integer GENERATED BY DEFAULT AS IDENTITY,
    "PorcentagemDesconto" numeric(5,2) NOT NULL,
    "CodigoCupom" VARCHAR(50) NOT NULL,
    "Status" boolean NOT NULL,
    CONSTRAINT "PK_cupom" PRIMARY KEY ("IdCupom")
);


CREATE TABLE endereco (
    "IdEndereco" integer GENERATED BY DEFAULT AS IDENTITY,
    "NmEndereco" VARCHAR(100) NOT NULL,
    "CEP" VARCHAR(9) NOT NULL,
    "Numero" integer NOT NULL,
    "Cidade" VARCHAR(50) NOT NULL,
    CONSTRAINT "PK_endereco" PRIMARY KEY ("IdEndereco")
);


CREATE TABLE forma_pagamento (
    "IdFormaPagamento" integer GENERATED BY DEFAULT AS IDENTITY,
    "NmFormaPagamento" VARCHAR(50) NOT NULL,
    CONSTRAINT "PK_forma_pagamento" PRIMARY KEY ("IdFormaPagamento")
);


CREATE TABLE produto (
    "IdProduto" integer GENERATED BY DEFAULT AS IDENTITY,
    "NmProduto" character varying(100) NOT NULL,
    "IdCategoria" integer NOT NULL,
    "Descricao" character varying(255) NOT NULL,
    "Valor" numeric(10,2) NOT NULL,
    CONSTRAINT "PK_produto" PRIMARY KEY ("IdProduto"),
    CONSTRAINT "FK_produto_categoria_produto_IdCategoria" FOREIGN KEY ("IdCategoria") REFERENCES categoria_produto ("IdCategoria") ON DELETE RESTRICT
);


CREATE TABLE pessoa (
    "IdPessoa" integer GENERATED BY DEFAULT AS IDENTITY,
    "Nome" character varying(100) NOT NULL,
    "Email" character varying(150) NOT NULL,
    "CPF" character varying(11) NOT NULL,
    "Telefone" character varying(20) NOT NULL,
    "IdEndereco" integer NOT NULL,
    CONSTRAINT "PK_pessoa" PRIMARY KEY ("IdPessoa"),
    CONSTRAINT "FK_pessoa_endereco_IdEndereco" FOREIGN KEY ("IdEndereco") REFERENCES endereco ("IdEndereco") ON DELETE RESTRICT
);


CREATE TABLE pedido (
    "IdPedido" integer GENERATED BY DEFAULT AS IDENTITY,
    "IdPessoa" integer NOT NULL,
    "IdCupom" integer NOT NULL,
    "IdEndereco" integer NOT NULL,
    "IdFormaPagamento" integer NOT NULL,
    CONSTRAINT "PK_pedido" PRIMARY KEY ("IdPedido"),
    CONSTRAINT "FK_pedido_cupom_IdCupom" FOREIGN KEY ("IdCupom") REFERENCES cupom ("IdCupom") ON DELETE RESTRICT,
    CONSTRAINT "FK_pedido_endereco_IdEndereco" FOREIGN KEY ("IdEndereco") REFERENCES endereco ("IdEndereco") ON DELETE RESTRICT,
    CONSTRAINT "FK_pedido_forma_pagamento_IdFormaPagamento" FOREIGN KEY ("IdFormaPagamento") REFERENCES forma_pagamento ("IdFormaPagamento") ON DELETE RESTRICT,
    CONSTRAINT "FK_pedido_pessoa_IdPessoa" FOREIGN KEY ("IdPessoa") REFERENCES pessoa ("IdPessoa") ON DELETE CASCADE
);


CREATE TABLE usuario (
    "IdUsuario" integer GENERATED BY DEFAULT AS IDENTITY,
    "IdPessoa" integer NOT NULL,
    "UsuarioLogin" character varying(50) NOT NULL,
    "Senha" character varying(255) NOT NULL,
    "DataExpiracao" timestamp with time zone NOT NULL,
    CONSTRAINT "PK_usuario" PRIMARY KEY ("IdUsuario"),
    CONSTRAINT "FK_usuario_pessoa_IdPessoa" FOREIGN KEY ("IdPessoa") REFERENCES pessoa ("IdPessoa") ON DELETE RESTRICT
);


CREATE TABLE pagamento (
    "IdPagamento" integer GENERATED BY DEFAULT AS IDENTITY,
    "IdPedido" integer NOT NULL,
    "Valor" numeric(10,2) NOT NULL,
    "StatusPagamento" character varying(20) NOT NULL,
    CONSTRAINT "PK_pagamento" PRIMARY KEY ("IdPagamento"),
    CONSTRAINT "FK_pagamento_pedido_IdPedido" FOREIGN KEY ("IdPedido") REFERENCES pedido ("IdPedido") ON DELETE CASCADE
);


CREATE TABLE pedido_item (
    "IdPedidoItem" integer GENERATED BY DEFAULT AS IDENTITY,
    "IdPedido" integer NOT NULL,
    "IdProduto" integer NOT NULL,
    CONSTRAINT "PK_pedido_item" PRIMARY KEY ("IdPedidoItem"),
    CONSTRAINT "FK_pedido_item_pedido_IdPedido" FOREIGN KEY ("IdPedido") REFERENCES pedido ("IdPedido") ON DELETE CASCADE,
    CONSTRAINT "FK_pedido_item_produto_IdProduto" FOREIGN KEY ("IdProduto") REFERENCES produto ("IdProduto") ON DELETE RESTRICT
);


CREATE INDEX "IX_pagamento_IdPedido" ON pagamento ("IdPedido");


CREATE INDEX "IX_pedido_IdCupom" ON pedido ("IdCupom");


CREATE INDEX "IX_pedido_IdEndereco" ON pedido ("IdEndereco");


CREATE INDEX "IX_pedido_IdFormaPagamento" ON pedido ("IdFormaPagamento");


CREATE INDEX "IX_pedido_IdPessoa" ON pedido ("IdPessoa");


CREATE INDEX "IX_pedido_item_IdPedido" ON pedido_item ("IdPedido");


CREATE INDEX "IX_pedido_item_IdProduto" ON pedido_item ("IdProduto");


CREATE INDEX "IX_pessoa_IdEndereco" ON pessoa ("IdEndereco");


CREATE INDEX "IX_produto_IdCategoria" ON produto ("IdCategoria");


CREATE INDEX "IX_usuario_IdPessoa" ON usuario ("IdPessoa");


