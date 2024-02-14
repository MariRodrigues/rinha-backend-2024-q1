CREATE DATABASE IF NOT EXISTS ContaBancaria;

USE ContaBancaria;

CREATE TABLE IF NOT EXISTS Clientes (
    Id INT PRIMARY KEY,
    Limite INT NOT NULL,
    Saldo INT NOT NULL
);

CREATE TABLE IF NOT EXISTS Transacoes (
    Id INT PRIMARY KEY,
    ClienteId INT NOT NULL,
    Valor INT NOT NULL,
    Tipo CHAR(1) NOT NULL,
    Descricao TEXT,
    Realizada_Em DATETIME NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

INSERT INTO Clientes (Id, Limite, Saldo) VALUES (1, 100000, 0);
INSERT INTO Clientes (Id, Limite, Saldo) VALUES (2, 80000, 0);
INSERT INTO Clientes (Id, Limite, Saldo) VALUES (3, 1000000, 0);
INSERT INTO Clientes (Id, Limite, Saldo) VALUES (4, 10000000, 0);
INSERT INTO Clientes (Id, Limite, Saldo) VALUES (5, 500000, 0);
