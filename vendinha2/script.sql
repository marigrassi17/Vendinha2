-- =====================================
-- CRIAÇÃO DO BANCO DE DADOS
-- =====================================

CREATE TABLE IF NOT EXISTS Clientes
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,

    NomeCompleto TEXT NOT NULL,

    CPF TEXT NOT NULL UNIQUE,

    DataNascimento TEXT NOT NULL,

    Email TEXT
);

-- =====================================
-- TABELA DE DÍVIDAS
-- =====================================

CREATE TABLE IF NOT EXISTS Dividas
(
    Id INTEGER PRIMARY KEY AUTOINCREMENT,

    ClienteId INTEGER NOT NULL,

    Valor REAL NOT NULL,

    Situacao TEXT NOT NULL,

    DataCriacao TEXT NOT NULL,

    DataPagamento TEXT,

    FOREIGN KEY (ClienteId)
    REFERENCES Clientes(Id)
);

-- =====================================
-- CONSULTA DE CLIENTES E DÍVIDAS
-- =====================================

SELECT
    Clientes.NomeCompleto,

    Clientes.CPF,

    Dividas.Valor,

    Dividas.Situacao

FROM Clientes

INNER JOIN Dividas
ON Clientes.Id = Dividas.ClienteId;

-- =====================================
-- CONSULTA DE TOTAL DE DÍVIDAS
-- =====================================

SELECT
    Clientes.NomeCompleto,

    SUM(Dividas.Valor) AS TotalDividas

FROM Clientes

INNER JOIN Dividas
ON Clientes.Id = Dividas.ClienteId

GROUP BY Clientes.Id;

-- =====================================
-- CONSULTA DE DÍVIDAS PENDENTES
-- =====================================

SELECT *
FROM Dividas
WHERE Situacao = 'Pendente';