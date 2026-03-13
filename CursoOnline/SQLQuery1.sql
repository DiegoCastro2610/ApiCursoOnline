CREATE DATABASE CursoOnline
GO

USE CursoOnline
GO

CREATE TABLE INSTRUTOR(
InstrutorID INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR(100),
AreaDeEspecializacao VARCHAR(100)
)
GO

CREATE TABLE ALUNO(
AlunoID INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR(100),
Email VARCHAR(100)
)
GO

CREATE TABLE CURSO(
CursoID INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR(100),
CargaHoraria INT,
StatusCurso BIT,
FK_InstrutorID INT FOREIGN KEY REFERENCES INSTRUTOR(InstrutorID)
)
GO

CREATE TABLE MATRICULA(
MatriculaID INT PRIMARY KEY IDENTITY NOT NULL,
FK_CursoID INT FOREIGN KEY REFERENCES CURSO(CursoID),
FK_AlunoID INT FOREIGN KEY REFERENCES ALUNO(AlunoID),
StatusMatricula BIT
)
GO

INSERT INTO INSTRUTOR (Nome, AreaDeEspecializacao)
VALUES 
('Carlos Silva', 'Programação'),
('Mariana Souza', 'Banco de Dados'),
('Ricardo Lima', 'Redes de Computadores')
GO

INSERT INTO ALUNO (Nome, Email)
VALUES
('João Pereira', 'joao@email.com'),
('Ana Costa', 'ana@email.com'),
('Lucas Martins', 'lucas@email.com'),
('Fernanda Alves', 'fernanda@email.com')
GO

INSERT INTO CURSO (Nome, CargaHoraria, StatusCurso, FK_InstrutorID)
VALUES
('SQL Server Básico', 40, 1, 2),
('Programação em C#', 60, 1, 1),
('Fundamentos de Redes', 30, 1, 3)
GO

INSERT INTO MATRICULA (FK_CursoID, FK_AlunoID, StatusMatricula)
VALUES
(1, 1, 1),
(1, 2, 1),
(2, 3, 1),
(3, 4, 1),
(2, 1, 1)
GO

    

