USE produtos_db;

CREATE TABLE tb_cadastro_prod (
  id_produto INT IDENTITY(1,1) NOT NULL, -- Alterado para IDENTITY
  desc_produto VARCHAR(255),
  data_lote VARCHAR(10),
  marca_produto VARCHAR(60) DEFAULT NULL,
  categoria_prod VARCHAR(100) DEFAULT NULL,
  qnt_dis_prod INT DEFAULT NULL,
  preco_custo DECIMAL(10,2) DEFAULT NULL,
  preco_venda DECIMAL(10,2) DEFAULT NULL,
  foto_prod VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (id_produto)
);


INSERT INTO tb_cadastro_prod (desc_produto, data_lote, marca_produto, categoria_prod, qnt_dis_prod, preco_custo, preco_venda, foto_prod) VALUES 
('Pneu Dianteiro 80/100-18','2026-04-14','Pirelli','Pneus',15,120.00,195.00,''),
('Pneu Traseiro 90/90-18','2026-04-14','Metzeler','Pneus',12,150.00,245.00,''),
('Kit Relação Completo','2026-04-14','DID','Transmissão',20,75.00,135.00,''),
('Pastilha de Freio Dianteira','2026-04-14','Cobreq','Freios',40,15.00,38.00,''),
('Lona de Freio Traseira','2026-04-14','Diafrag','Freios',35,12.00,29.00,''),
('Óleo Mobil 20W50 1L','2026-04-14','Mobil','Lubrificantes',100,22.00,35.00,''),
('Vela de Ignição G7HS','2026-04-14','NGK','Motor',50,8.00,19.50,''),
('Cabo de Embreagem','2026-04-14','Soretto','Cabos',18,9.50,26.00,''),
('Filtro de Ar Titan 150','2026-04-14','Valflex','Filtros',25,11.00,28.50,''),
('Amortecedor Traseiro Par','2026-04-14','Cofap','Suspensão',4,190.00,330.00,''),
('Lâmpada Farol H4 35W','2026-04-14','Philips','Elétrica',30,10.50,24.00,''),
('Disco de Freio Dianteiro','2026-04-14','Scud','Freios',8,55.00,98.00,''),
('Câmara de Ar Aro 18','2026-04-14','Tortuga','Pneus',45,18.00,42.00,''),
('Retentor de Bengala','2026-04-14','Corteco','Suspensão',20,14.00,45.00,''),
('Manete de Freio Prata','2026-04-14','Cometa','Guidão',15,12.00,32.00,''),
('Retrovisor Par Mod. Original','2026-04-14','GVS','Acessórios',22,25.00,55.00,''),
('Kit Cilindro e Pistão 125','2026-04-14','MetalLeve','Motor',5,160.00,295.00,''),
('Junta do Cabeçote','2026-04-14','Vedamotors','Motor',12,5.00,14.00,''),
('Manopla Esportiva Preta','2026-04-14','Circuit','Acessórios',15,14.50,35.00,'')

Select * from tb_vendas;


CREATE TABLE tb_movimentacoes (
  id_mov INT IDENTITY(1,1) NOT NULL,
  id_produto INT NOT NULL,
  tipo_operacao VARCHAR(10) NOT NULL,
  quantidade INT NOT NULL,
  data_movimentacao DATETIME DEFAULT GETDATE(), -- GETDATE() em vez de CURRENT_TIMESTAMP
  vendidos INT DEFAULT 0,
  valor_total_venda DECIMAL(10,2) DEFAULT 0.00,
  PRIMARY KEY (id_mov),
  CONSTRAINT fk_produto FOREIGN KEY (id_produto) REFERENCES tb_cadastro_prod (id_produto)
);

-- Tabela de Vendas
CREATE TABLE tb_vendas (
  id_venda INT IDENTITY(1,1) NOT NULL,
  id_produto INT NOT NULL,
  quantidade INT NOT NULL,
  valor_unitario DECIMAL(10,2) NOT NULL,
  -- Sintaxe de coluna calculada no SQL Server
  valor_total_item AS (quantidade * valor_unitario), 
  forma_pagamento VARCHAR(20) DEFAULT NULL,
  data_venda DATETIME DEFAULT GETDATE(),
  PRIMARY KEY (id_venda),
  CONSTRAINT fk_produto_venda FOREIGN KEY (id_produto) REFERENCES tb_cadastro_prod (id_produto)
);

