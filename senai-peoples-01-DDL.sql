--DDL Linguagem de Definição de Dados

CREATE DATABASE M_Peoples;

USE M_Peoples;

--Criando tabelas 
CREATE TABLE Funcionario(
	IDFuncionario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(222),
);
GO

SELECT * FROM Funcionario