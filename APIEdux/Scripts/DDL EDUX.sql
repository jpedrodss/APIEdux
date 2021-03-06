CREATE DATABASE Edux;
GO
USE Edux;
GO

CREATE TABLE Perfil(
	IdPerfil INT PRIMARY KEY IDENTITY NOT NULL,

	Permissao VARCHAR(50)
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,

	Nome VARCHAR(255),
	Email VARCHAR(100),
	Senha VARCHAR(255),
	DataCadastro DATETIME,
	DataUltimoAcesso DATETIME,

	IdPerfil INT FOREIGN KEY REFERENCES Perfil(IdPerfil) NOT NULL
);

CREATE TABLE Dica(
	IdDica INT PRIMARY KEY IDENTITY NOT NULL,

	Texto VARCHAR(255),
	UrlImagem VARCHAR(255),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL
);

CREATE TABLE Curtida(
	IdCurtida INT PRIMARY KEY IDENTITY NOT NULL,

	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdDica INT FOREIGN KEY REFERENCES Dica(IdDica) NOT NULL
);

CREATE TABLE Instituicao(
	IdInstituicao INT PRIMARY KEY IDENTITY NOT NULL,

	Nome VARCHAR(255),
	Logradouro VARCHAR(255),
	Numero VARCHAR(255),
	Complemento VARCHAR(255),
	Bairro VARCHAR(255),
	Cidade VARCHAR(255),
	UF VARCHAR(2),
	CEP VARCHAR(15)
);

CREATE TABLE Curso(
	IdCurso INT PRIMARY KEY IDENTITY NOT NULL,

	Titulo VARCHAR(255),

	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao(IdInstituicao) NOT NULL
);

CREATE TABLE Turma(
	IdTurma INT PRIMARY KEY IDENTITY NOT NULL,

	Descricao VARCHAR(255),

	IdCurso INT FOREIGN KEY REFERENCES Curso(IdCurso) NOT NULL
);

CREATE TABLE AlunoTurma(
	IdAlunoTurma INT PRIMARY KEY IDENTITY NOT NULL,

	Matricula VARCHAR(50),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdTurma INT FOREIGN KEY REFERENCES Turma(IdTurma) NOT NULL
);

CREATE TABLE ProfessorTurma(
	IdProfessorTurma INT PRIMARY KEY IDENTITY NOT NULL,

	Descricao VARCHAR(255),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario) NOT NULL,
	IdTurma INT FOREIGN KEY REFERENCES Turma(IdTurma) NOT NULL
);

CREATE TABLE Categoria(
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL,

	Descricao VARCHAR(255)
);

CREATE TABLE Objetivo(
	IdObjetivo INT PRIMARY KEY IDENTITY NOT NULL,

	Descricao VARCHAR(255),

	IdCategoria INT FOREIGN KEY REFERENCES Categoria(IdCategoria) NOT NULL
);

CREATE TABLE ObjetivoAluno(
	IdObjetivoAluno INT PRIMARY KEY IDENTITY NOT NULL,

	Nota DECIMAL DEFAULT NULL,
	DataAlcancado DATETIME,

	IdAlunoTurma INT FOREIGN KEY REFERENCES AlunoTurma(IdAlunoTurma) NOT NULL,
	IdObjetivo INT FOREIGN KEY REFERENCES Objetivo(IdObjetivo) NOT NULL
);

INSERT INTO Perfil (Permissao) VALUES 
	('Administrador'),
	('Padrão'),
	('Professor')