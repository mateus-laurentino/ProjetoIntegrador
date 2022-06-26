CREATE DATABASE Evento

USE Evento

DROP TABLE InfoEvento
DROP TABLE Usuario
DROP TABLE Logado
DROP TABLE EventoParticipante
DROP TABLE CartaoUsuario

CREATE TABLE InfoEvento
(
	Id INT IDENTITY(1,1) not null,
	Imagem VARCHAR(500) null,
	Nome VARCHAR(70) not null,
	Localidade VARCHAR(70) not null,
	DataEHora SMALLDATETIME not null,
	QtdeTotalPessoa INT not null,
	Categoria SMALLINT not null,
	IdUsuario INT not null
)

CREATE TABLE Usuario
(
	Id INT IDENTITY(1,1) not null,
	Usuario VARCHAR(20) not null,
	Password VARCHAR(20) not null,
	Nome VARCHAR(100) not null,
	Idade INT not null,
	DataNascimento DATETIME not null
)

CREATE TABLE Logado
(
	Id INT IDENTITY(1,1) NOT NULL,
	UsuarioLogado BIT NOT NULL,
	Usuario VARCHAR(100) NOT NULL
)

CREATE TABLE EventoParticipante
(
	Id INT IDENTITY(1,1) NOT NULL,
	IdEvento INT NOT NULL,
	IdUsuario INT NOT NULL
)

CREATE TABLE CartaoUsuario
(
	Id INT IDENTITY(1,1) NOT NULL,
	IdUsuario INT,
	NumeroCartao VARCHAR(20) NOT NULL,
	NomeCartao VARCHAR(50) NOT NULL,
	Cvc INT NOT NULL,
	DataVencimento DATETIME NOT NULL
)

SELECT * FROM Evento.dbo.InfoEvento
SELECT * FROM Evento.dbo.Usuario
SELECT * FROM Evento.dbo.Logado
SELECT * FROM Evento.dbo.EventoParticipante
SELECT * FROM Evento.dbo.CartaoUsuario


INSERT INTO Evento.dbo.InfoEvento (Nome, Localidade, DataEHora, QtdeTotalPessoa, Categoria, IdUsuario)
VALUES ('Mateus', 'Seila', GETDATE(), 100, 3, 2);

INSERT INTO Evento.dbo.Usuario (Usuario, Password, Nome, Idade, DataNascimento)
VALUES ('MateusL', '88455647', 'Mateus Laurentino', 26, GETDATE())

INSERT INTO Evento.dbo.Logado (UsuarioLogado, Usuario)
VALUES (1, 'MateusL')