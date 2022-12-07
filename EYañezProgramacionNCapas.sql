CREATE DATABASE EYañezProgramacionNCapas

USE EYañezProgramacionNCapas

CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50)NOT NULL,
	ApellidoMaterno VARCHAR(50)NOT NULL,
	Sexo CHAR(2),
	FechaNacimiento DATE,
	Password VARCHAR(50),
	UserName VARCHAR(50)
)

INSERT INTO [dbo].[Usuario]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Sexo]
           ,[FechaNacimiento]
           ,[Email]
           ,[Password]
           ,[UserName])
     VALUES
           ('Erick Alejandro'
           ,'Yañez'
           ,'Aguilar'
           ,'M'
           ,'2000/06/06'
           ,'eryanez46@gmail.com'
           ,'123456789'
           ,'ErickAguilar')
GO

INSERT INTO [dbo].[Usuario]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Sexo]
           ,[FechaNacimiento]
           ,[Email]
           ,[Password]
           ,[UserName])
     VALUES
           ('Daniel'
           ,'Hernandez'
           ,'Vergara'
           ,'M'
           ,'2000/05/12'
           ,'danhernan@gmail.com'
           ,'987654321'
           ,'DaniHernandez')
GO

ALTER PROCEDURE UsuarioAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sexo CHAR(2),
@FechaNacimiento VARCHAR(20),
@Password CHAR(50),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@CURP VARCHAR(20),
@UserName VARCHAR(50),
@Email VARCHAR(100),
@IdRol TINYINT
AS
	INSERT INTO [dbo].[Usuario]
			   ([Nombre]
			   ,[ApellidoPaterno]
			   ,[ApellidoMaterno]
			   ,[Sexo]
			   ,[FechaNacimiento]
			   ,[Password]
			   ,[Telefono]
			   ,[Celular]
			   ,[CURP]
			   ,[UserName]
			   ,[Email]
			   ,[IdRol])
		 VALUES
			   (@Nombre
			   ,@ApellidoPaterno
			   ,@ApellidoMaterno
			   ,@Sexo
			   ,CONVERT(DATE, @FechaNacimiento,105)
			   ,@Password
			   ,@Telefono
			   ,@Celular
			   ,@CURP
			   ,@UserName
			   ,@Email
			   ,@IdRol)
GO

ALTER PROCEDURE UsuarioGetAll
AS
	SELECT Usuario.[IdUsuario]
		  ,Usuario.[Nombre]
		  ,Usuario.[ApellidoPaterno]
		  ,Usuario.[ApellidoMaterno]
		  ,Usuario.[Sexo]
		  ,Usuario.[FechaNacimiento]
		  ,Usuario.[Password]
		  ,Usuario.[Telefono]
		  ,Usuario.[Celular]
	      ,Usuario.[CURP]
		  ,Usuario.[UserName]
		  ,Usuario.[Email]
		  ,Usuario.[IdRol]
		  ,Rol.[Nombre] AS NombreRol
	  FROM [Usuario]
	  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
GO

CREATE PROCEDURE RolGetAll
AS
	SELECT [IdRol]
          ,[Nombre]
    FROM [Rol]
GO

UsuarioGetAll
GO

ALTER PROCEDURE UsuarioGetById 
@IdUsuario TINYINT
AS
	SELECT Usuario.[IdUsuario]
		  ,Usuario.[Nombre]
		  ,Usuario.[ApellidoPaterno]
		  ,Usuario.[ApellidoMaterno]
		  ,Usuario.[Sexo]
		  ,Usuario.[FechaNacimiento]
		  ,Usuario.[Password]
		  ,Usuario.[Telefono]
		  ,Usuario.[Celular]
	      ,Usuario.[CURP]
		  ,Usuario.[UserName]
		  ,Usuario.[Email]
		  ,Usuario.[IdRol]
	  FROM [Usuario]
	  WHERE Usuario.[IdUsuario] = @IdUsuario
GO

UsuarioGetById 1
GO

ALTER PROCEDURE UsuarioDelete
@IdUsuario TINYINT
AS
	DELETE FROM [dbo].[Usuario]
      WHERE Usuario.[IdUsuario] = @IdUsuario
GO

UsuarioDelete 1
GO

ALTER PROCEDURE UsuarioUpdate
@IdUsuario TINYINT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sexo CHAR(2),
@FechaNacimiento VARCHAR(20),
@Password CHAR(50),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@CURP VARCHAR(20),
@UserName VARCHAR(50),
@Email VARCHAR(100),
@IdRol TINYINT
AS
	UPDATE [dbo].[Usuario]
	SET [Nombre] = @Nombre
      ,[ApellidoPaterno] = @ApellidoPaterno
      ,[ApellidoMaterno] = @ApellidoMaterno
      ,[Sexo] = @Sexo
      ,[FechaNacimiento] = CONVERT(DATE, @FechaNacimiento,105)
	  ,[Password] = @Password
	  ,[Telefono] = @Telefono
	  ,[Celular] = @Celular
	  ,[CURP] = @CURP
	  ,[UserName] =@UserName
	  ,[Email] = @Email
	  ,[IdRol] = @IdRol
	 WHERE Usuario.[IdUsuario] = @IdUsuario
GO

CREATE TABLE Rol
(
	IdRol TINYINT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

--Tabla Empresa--

CREATE TABLE Empresa
(
	IdEmpresa INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50)NOT NULL,
	Telefono VARCHAR(50) NOT NULL,
	Email VARCHAR(254) NOT NULL UNIQUE,
	DireccionWeb VARCHAR(100) NOT NULL UNIQUE
)
GO

INSERT INTO [dbo].[Empresa]
			   ([Nombre]
			   ,[Telefono]
			   ,[Email]
			   ,[DireccionWeb])
		 VALUES
			   ('Grupo Televisa S.A.'
			   ,'5552245000'
			   ,'grupotelevisa@televisa.com'
			   ,'https://www.televisa.com/')
GO

INSERT INTO [dbo].[Empresa]
			   ([Nombre]
			   ,[Telefono]
			   ,[Email]
			   ,[DireccionWeb])
		 VALUES
			   ('Grupo Bimbo, S.A.B. de C.V.'
			   ,'018009102030'
			   ,'atencionenlinea@grupobimbo.com'
			   ,'https://www.grupobimbo.com/es')
GO

INSERT INTO [dbo].[Empresa]
			   ([Nombre]
			   ,[Telefono]
			   ,[Email]
			   ,[DireccionWeb])
		 VALUES
			   ('Infonavit'
			   ,'8000083900'
			   ,'Casia@infonavit.org.mx'
			   ,'https://portalmx.infonavit.org.mx/')
GO

INSERT INTO [dbo].[Empresa]
			   ([Nombre]
			   ,[Telefono]
			   ,[Email]
			   ,[DireccionWeb])
		 VALUES
			   ('Hewlett-Packard'
			   ,'5550912455'
			   ,'soportetecnico@hp.mx'
			   ,'https://www.hp.com/')
GO

ALTER PROCEDURE EmpresaAdd
@Nombre VARCHAR(50),
@Telefono VARCHAR(20),
@Email VARCHAR(254),
@DireccionWeb VARCHAR(100),
@Logo VARCHAR(MAX)
AS
	INSERT INTO [dbo].[Empresa]
			   ([Nombre]
			   ,[Telefono]
			   ,[Email]
			   ,[DireccionWeb]
			   ,[Logo])
		 VALUES
			   (@Nombre
			   ,@Telefono
			   ,@Email
			   ,@DireccionWeb
			   ,@Logo)
GO

ALTER PROCEDURE EmpresaGetAll 'televisa'
@Nombre VARCHAR(50)
AS
	SELECT Empresa.[IdEmpresa]
		  ,Empresa.[Nombre]
		  ,Empresa.[Telefono]
		  ,Empresa.[Email]
		  ,Empresa.[DireccionWeb]
		  ,Empresa.[Logo]
	  FROM [Empresa]
	  WHERE Empresa.Nombre LIKE '%' + @Nombre + '%'
GO

ALTER PROCEDURE EmpresaGetById 
@IdEmpresa INT
AS
	SELECT Empresa.[IdEmpresa]
		  ,Empresa.[Nombre]
		  ,Empresa.[Telefono]
		  ,Empresa.[Email]
		  ,Empresa.[DireccionWeb]
		  ,Empresa.[Logo]
	  FROM [Empresa]
	  WHERE Empresa.[IdEmpresa] = @IdEmpresa
GO

ALTER PROCEDURE EmpresaDelete 
@IdEmpresa INT
AS
	DELETE FROM [dbo].[Empresa]
      WHERE Empresa.[IdEmpresa] = @IdEmpresa
GO

ALTER PROCEDURE EmpresaUpdate
@IdEmpresa INT,
@Nombre VARCHAR(50),
@Telefono VARCHAR(20),
@Email VARCHAR(254),
@DireccionWeb VARCHAR(100),
@Logo VARCHAR(MAX)
AS
	UPDATE [dbo].[Empresa]
	SET [Nombre] = @Nombre
	  ,[Telefono] = @Telefono
	  ,[Email] = @Email
	  ,[DireccionWeb] = @DireccionWeb
	  ,[Logo] = @Logo
	 WHERE Empresa.[IdEmpresa] = @IdEmpresa
GO

CREATE TABLE Pais
(
	IdPais INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Estado
(
	IdEstado INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	IdPais INT
	CONSTRAINT FK_PaisOrder FOREIGN KEY (IdPais)
    REFERENCES Pais(IdPais)
)

CREATE TABLE Municipio
(
	IdMunicipio INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	IdEstado INT
	CONSTRAINT FK_EstadoOrder FOREIGN KEY (IdEstado)
    REFERENCES Estado(IdEstado)
)

CREATE TABLE Colonia
(
	IdColonia INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	CodigoPostal VARCHAR(50) NOT NULL,
	IdMunicipio INT
	CONSTRAINT FK_MunicipioOrder FOREIGN KEY (IdMunicipio)
    REFERENCES Municipio(IdMunicipio)
)

CREATE TABLE Direccion
(
	IdDireccion INT IDENTITY(1,1) PRIMARY KEY,
	Calle VARCHAR(50) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	NumeroInterior VARCHAR(20) NOT NULL,
	NumeroExterior VARCHAR(20) NOT NULL,
	IdColonia INT,
	IdUsuario TINYINT
	CONSTRAINT FK_ColoniaOrder FOREIGN KEY (IdColonia)
    REFERENCES Colonia(IdColonia),
	CONSTRAINT FK_UsuarioOrder FOREIGN KEY (IdUsuario)
    REFERENCES Usuario(IdUsuario)
)


INSERT INTO [Pais]([Nombre])VALUES('Mexico')
INSERT INTO [Pais]([Nombre])VALUES('Estados Unidos')
INSERT INTO [Pais]([Nombre])VALUES('Canada')
INSERT INTO [Pais]([Nombre])VALUES('España')
INSERT INTO [Pais]([Nombre])VALUES('Italia')
INSERT INTO [Pais]([Nombre])VALUES('Francia')
INSERT INTO [Pais]([Nombre])VALUES('Inglaterra')
INSERT INTO [Pais]([Nombre])VALUES('Brasil')
INSERT INTO [Pais]([Nombre])VALUES('Argentina')
INSERT INTO [Pais]([Nombre])VALUES('Colombia')

INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Jalisco',1)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Guanajuato',1)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Buenos Aires',9)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Ontario',3)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Rio de Janeiro',8)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Londres',7)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Paris',6)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Roma',5)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Madrid',4)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('California',2)
INSERT INTO [Estado]([Nombre],[IdPais])VALUES('Bogota',10)

INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('El Rosal',10)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('La Boca',9)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Madrid',4)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Region Metropolitana',8)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Enfield',7)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Bourse',6)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Ostia',5)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Toronto',3)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Anderson',2)
INSERT INTO [Municipio]([Nombre],[IdEstado])VALUES('Guadalajara',1)

INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('El rodeo','98775',10)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('La bombonera','65544',9)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Malasia','48995',4)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Mesquita','26613',8)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Oakwood','62622',7)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Place du carie','49855',6)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Antica','69986',5)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Graffiti Alley','744885',3)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('River Black','55511',2)
INSERT INTO [Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Santa Cecilia','44940',1)
GO

CREATE PROCEDURE PaisGetAll
AS
	SELECT [IdPais]
	  ,[Nombre]
	FROM [Pais]
GO

CREATE PROCEDURE EstadoGetByIdPais
@IdPais INT
AS
	SELECT [IdEstado]
      ,[Nombre]
      ,[IdPais]
  FROM [Estado]
  WHERE Estado.[IdPais] = @IdPais
GO

CREATE PROCEDURE MunicipioGetByIdEstado
@IdEstado INT
AS
	SELECT [IdMunicipio]
      ,[Nombre]
      ,[IdEstado]
  FROM [Municipio]
  WHERE Municipio.[IdEstado] = @IdEstado
GO

CREATE PROCEDURE ColoniaGetByIdMunicipio
@IdMunicipio INT
AS
	SELECT [IdColonia]
      ,[Nombre]
      ,[CodigoPostal]
      ,[IdMunicipio]
  FROM [Colonia]
  WHERE Colonia.[IdMunicipio] = @IdMunicipio
GO

UsuarioAdd 'Ruben','Quiroz','Torres','H','11/11/2000','95558956','29595589','55959598','RUSN4899655','RubenQuiroz','rubenq@gmail.com',2,'Flores','Mz 44','Lt 47',1
GO

ALTER PROCEDURE UsuarioAdd 
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sexo CHAR(2),
@FechaNacimiento VARCHAR(20),
@Password CHAR(50),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@CURP VARCHAR(20),
@UserName VARCHAR(50),
@Email VARCHAR(100),
@IdRol TINYINT,
@Imagen VARCHAR(MAX),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT
AS
	INSERT INTO [Usuario]
			   ([Nombre]
			   ,[ApellidoPaterno]
			   ,[ApellidoMaterno]
			   ,[Sexo]
			   ,[FechaNacimiento]
			   ,[Password]
			   ,[Telefono]
			   ,[Celular]
			   ,[CURP]
			   ,[UserName]
			   ,[Email]
			   ,[IdRol]
			   ,[Imagen])
		 VALUES
			   (@Nombre
			   ,@ApellidoPaterno
			   ,@ApellidoMaterno
			   ,@Sexo
			   ,CONVERT(DATE, @FechaNacimiento,105)
			   ,@Password
			   ,@Telefono
			   ,@Celular
			   ,@CURP
			   ,@UserName
			   ,@Email
			   ,@IdRol
			   ,@Imagen)
	INSERT INTO [Direccion]
           ([Calle]
           ,[NumeroInterior]
           ,[NumeroExterior]
           ,[IdColonia]
           ,[IdUsuario])
     VALUES
           (@Calle
           ,@NumeroInterior
           ,@NumeroExterior
           ,@IdColonia
           ,@@IDENTITY)
GO

ALTER PROCEDURE UsuarioGetAll '','',0
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@IdRol TINYINT
AS
	IF(@IdRol > 0)
	BEGIN
		SELECT Usuario.[IdUsuario]
			  ,Usuario.[Nombre]
			  ,Usuario.[ApellidoPaterno]
			  ,Usuario.[ApellidoMaterno]
			  ,Usuario.[Sexo]
			  ,Usuario.[FechaNacimiento]
			  ,Usuario.[Password]
			  ,Usuario.[Telefono]
			  ,Usuario.[Celular]
			  ,Usuario.[CURP]
			  ,Usuario.[UserName]
			  ,Usuario.[Email]
			  ,Usuario.[Imagen]
			  ,Usuario.[Status]
			  ,Usuario.[IdRol]
			  ,Rol.[Nombre] AS NombreRol
			  ,Direccion.[IdDireccion]
			  ,Direccion.[Calle]
			  ,Direccion.[NumeroInterior]
			  ,Direccion.[NumeroExterior]
			  ,Direccion.[IdColonia]
			  ,Colonia.[Nombre] AS NombreColonia
			  ,Colonia.[CodigoPostal]
			  ,Colonia.[IdMunicipio]
			  ,Municipio.[Nombre] AS NombreMunicipio
			  ,Municipio.[IdEstado]
			  ,Estado.[Nombre] AS NombreEstado
			  ,Estado.[IdPais]
			  ,Pais.[Nombre] AS NombrePais
		  FROM [Usuario]
		  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
		  INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.IdUsuario
		  INNER JOIN Colonia ON Direccion.IdColonia = Colonia.IdColonia
		  INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
		  INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
		  INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
		  WHERE Usuario.Nombre LIKE '%' + @Nombre + '%' AND Usuario.ApellidoPaterno LIKE '%' + @ApellidoPaterno + '%' AND Usuario.IdRol = @IdRol
	END
	ELSE
	BEGIN
		SELECT Usuario.[IdUsuario]
			  ,Usuario.[Nombre]
			  ,Usuario.[ApellidoPaterno]
			  ,Usuario.[ApellidoMaterno]
			  ,Usuario.[Sexo]
			  ,Usuario.[FechaNacimiento]
			  ,Usuario.[Password]
			  ,Usuario.[Telefono]
			  ,Usuario.[Celular]
			  ,Usuario.[CURP]
			  ,Usuario.[UserName]
			  ,Usuario.[Email]
			  ,Usuario.[Imagen]
			  ,Usuario.[Status]
			  ,Usuario.[IdRol]
			  ,Rol.[Nombre] AS NombreRol
			  ,Direccion.[IdDireccion]
			  ,Direccion.[Calle]
			  ,Direccion.[NumeroInterior]
			  ,Direccion.[NumeroExterior]
			  ,Direccion.[IdColonia]
			  ,Colonia.[Nombre] AS NombreColonia
			  ,Colonia.[CodigoPostal]
			  ,Colonia.[IdMunicipio]
			  ,Municipio.[Nombre] AS NombreMunicipio
			  ,Municipio.[IdEstado]
			  ,Estado.[Nombre] AS NombreEstado
			  ,Estado.[IdPais]
			  ,Pais.[Nombre] AS NombrePais
		  FROM [Usuario]
		  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
		  INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.IdUsuario
		  INNER JOIN Colonia ON Direccion.IdColonia = Colonia.IdColonia
		  INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
		  INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
		  INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
		  WHERE Usuario.Nombre LIKE '%' + @Nombre + '%' AND Usuario.ApellidoPaterno LIKE '%' + @ApellidoPaterno + '%' OR Usuario.IdRol = @IdRol 
	END
GO

ALTER PROCEDURE UsuarioGetById
@IdUsuario TINYINT
AS
	SELECT Usuario.[IdUsuario]
		  ,Usuario.[Nombre]
		  ,Usuario.[ApellidoPaterno]
		  ,Usuario.[ApellidoMaterno]
		  ,Usuario.[Sexo]
		  ,Usuario.[FechaNacimiento]
		  ,Usuario.[Password]
		  ,Usuario.[Telefono]
		  ,Usuario.[Celular]
		  ,Usuario.[CURP]
		  ,Usuario.[Username]
		  ,Usuario.[Email]
		  ,Usuario.[Imagen]
		  ,Usuario.[Status]
		  ,Usuario.[IdRol]
		  ,Rol.[Nombre] AS NombreRol
		  ,Direccion.[IdDireccion]
		  ,Direccion.[Calle]
		  ,Direccion.[NumeroInterior]
		  ,Direccion.[NumeroExterior]
		  ,Direccion.[IdColonia]
		  ,Colonia.[Nombre] AS NombreColonia
		  ,Colonia.[CodigoPostal]
		  ,Colonia.[IdMunicipio]
		  ,Municipio.[Nombre] AS NombreMunicipio
		  ,Municipio.[IdEstado]
		  ,Estado.[Nombre] AS NombreEstado
		  ,Estado.[IdPais]
		  ,Pais.[Nombre] AS NombrePais
	  FROM [Usuario]
	  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
	  INNER JOIN Direccion ON Usuario.IdUsuario = Direccion.IdUsuario
	  INNER JOIN Colonia ON Direccion.IdColonia = Colonia.IdColonia
	  INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
	  INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
	  INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
	  WHERE Usuario.[IdUsuario] = @IdUsuario
GO

ALTER PROCEDURE UsuarioUpdate
@IdUsuario TINYINT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Sexo CHAR(2),
@FechaNacimiento VARCHAR(20),
@Password CHAR(50),
@Telefono VARCHAR(20),
@Celular VARCHAR(20),
@CURP VARCHAR(20),
@UserName VARCHAR(50),
@Email VARCHAR(100),
@IdRol TINYINT,
@Imagen VARCHAR(MAX),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT
AS
	UPDATE [Usuario]
	SET [Nombre] = @Nombre
      ,[ApellidoPaterno] = @ApellidoPaterno
      ,[ApellidoMaterno] = @ApellidoMaterno
      ,[Sexo] = @Sexo
      ,[FechaNacimiento] = CONVERT(DATE, @FechaNacimiento,105)
	  ,[Password] = @Password
	  ,[Telefono] = @Telefono
	  ,[Celular] = @Celular
	  ,[CURP] = @CURP
	  ,[UserName] =@UserName
	  ,[Email] = @Email
	  ,[IdRol] = @IdRol
	  ,[Imagen] = @Imagen
	 WHERE Usuario.[IdUsuario] = @IdUsuario

	 UPDATE [Direccion]
	 SET [Calle] = @Calle
      ,[NumeroInterior] = @NumeroInterior
      ,[NumeroExterior] = @NumeroExterior
      ,[IdColonia] = @IdColonia
	 WHERE Direccion.[IdUsuario] = @IdUsuario
GO

UsuarioUpdate 23,'Ruben','Quiroz','Torres','H','11/11/2000','95558956','29595589','55959598','RUSN4899655','RubenQuiroz','rubenq@gmail.com',2,'Flores','Mz 44','Lt 47',1
GO

ALTER PROCEDURE UsuarioDelete
@IdUsuario TINYINT
AS
	DELETE FROM [Direccion]
      WHERE Direccion.[IdUsuario] = @IdUsuario
	DELETE FROM [Usuario]
      WHERE Usuario.[IdUsuario] = @IdUsuario
GO

UPDATE Usuario
SET Imagen = Null

ALTER TABLE Usuario
DROP COLUMN Imagen 

ALTER TABLE Usuario
ADD Imagen VARCHAR(MAX)

UPDATE Empresa
SET Logo = Null 

ALTER TABLE Empresa
DROP COLUMN Logo

ALTER TABLE Empresa
ADD Logo VARCHAR(MAX)

CREATE TABLE Aseguradora
(
	IdAseguradora INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	FechaCreacion DATETIME NOT NULL,
	FechaModificacion DATETIME NOT NULL,
	IdUsuario TINYINT,
	CONSTRAINT FK_Usuario1Order FOREIGN KEY (IdUsuario)
    REFERENCES Usuario(IdUsuario)
)
GO

ALTER PROCEDURE AseguradoraAdd
@Nombre VARCHAR(50),
@IdUsuario TINYINT
AS
	INSERT INTO [dbo].[Aseguradora]
           ([Nombre]
           ,[FechaCreacion]
           ,[FechaModificacion]
           ,[IdUsuario])
     VALUES
           (@Nombre
		   ,GETDATE()
		   ,GETDATE()
           ,@IdUsuario)
GO


ALTER PROCEDURE AseguradoraGetAll 
AS
	SELECT [IdAseguradora]
      ,Aseguradora.[Nombre]
      ,Aseguradora.[FechaCreacion]
      ,Aseguradora.[FechaModificacion]
      ,Aseguradora.[IdUsuario]
	  ,Usuario.[Nombre] AS NombreUsuario
	  ,Usuario.[ApellidoPaterno]
	  ,Usuario.[ApellidoMaterno]
	FROM [dbo].[Aseguradora]
	  INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario
GO

ALTER PROCEDURE AseguradoraGetById
@IdAseguradora INT
AS
	SELECT [IdAseguradora]
      ,Aseguradora.[Nombre]
      ,Aseguradora.[FechaCreacion]
      ,Aseguradora.[FechaModificacion]
      ,Aseguradora.[IdUsuario]
	  ,Usuario.[Nombre] AS NombreUsuario
	  ,Usuario.[ApellidoPaterno]
	  ,Usuario.[ApellidoMaterno]
	FROM [dbo].[Aseguradora]
	  INNER JOIN Usuario ON Aseguradora.IdUsuario = Usuario.IdUsuario
	  WHERE Aseguradora.[IdAseguradora] = @IdAseguradora
GO

ALTER PROCEDURE AseguradoraUpdate
@IdAseguradora INT,
@Nombre VARCHAR(50),
@IdUsuario TINYINT
AS
	UPDATE [dbo].[Aseguradora]
   SET [Nombre] = @Nombre
      ,[FechaModificacion] = GETDATE()
      ,[IdUsuario] = @IdUsuario
	WHERE Aseguradora.[IdAseguradora] = @IdAseguradora
GO

ALTER PROCEDURE AseguradoraDelete
@IdAseguradora INT
AS
	DELETE FROM [dbo].[Aseguradora]
		  WHERE Aseguradora.[IdAseguradora] = @IdAseguradora
GO

ALTER TABLE Usuario
ADD Status BIT
GO

CREATE PROCEDURE UsuarioChangeStatus
@IdUsuario TINYINT,
@Status BIT
AS
	UPDATE Usuario
	SET
	Usuario.[Status] = @Status
	WHERE IdUsuario = @IdUsuario
GO

CREATE TABLE Empleado
(
	NumeroEmpleado VARCHAR(50) PRIMARY KEY,
	RFC VARCHAR(20),
	Nombre VARCHAR(50) NOT NULL,
	ApellidoPaterno VARCHAR(50) NOT NULL,
	ApellidoMaterno VARCHAR(50) NULL,
	Email VARCHAR(254) NOT NULL UNIQUE,
	FechaNacimiento DATE NULL,
	NSS VARCHAR(20),
	FechaIngreso DATE,
	Foto VARCHAR(MAX),
	IdEmpresa INT
	CONSTRAINT FK_EmpresaOrder FOREIGN KEY (IdEmpresa)
    REFERENCES Empresa(IdEmpresa)
)
GO

ALTER PROCEDURE EmpleadoAdd 
@NumeroEmpleado VARCHAR(50),
@RFC VARCHAR(20),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@FechaNacimiento DATE,
@NSS VARCHAR(20),
@FechaIngreso DATE,
@Foto VARCHAR(MAX),
@IdEmpresa INT

AS
	INSERT INTO [Empleado]
           ([NumeroEmpleado]
           ,[RFC]
           ,[Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[Email]
           ,[FechaNacimiento]
           ,[NSS]
           ,[FechaIngreso]
           ,[Foto]
           ,[IdEmpresa])
     VALUES
           (@NumeroEmpleado
           ,@RFC
           ,@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
           ,@Email
           ,CONVERT(DATE, @FechaNacimiento,105)
           ,@NSS
           ,@FechaIngreso
           ,@Foto
           ,@IdEmpresa)
GO

ALTER PROCEDURE EmpleadoGetAll 
AS
	SELECT [NumeroEmpleado]
      ,[RFC]
      ,Empleado.[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,Empleado.[Email]
      ,[FechaNacimiento]
      ,[NSS]
      ,[FechaIngreso]
      ,[Foto]
      ,Empresa.[IdEmpresa]
	  ,Empresa.[Nombre] AS NombreEmpresa
  FROM [Empleado]
  INNER JOIN Empresa ON Empleado.IdEmpresa = Empresa.IdEmpresa
GO

ALTER PROCEDURE EmpleadoGetById
@NumeroEmpleado VARCHAR(50)
AS
	SELECT [NumeroEmpleado]
      ,[RFC]
      ,Empleado.[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
      ,Empleado.[Email]
      ,[FechaNacimiento]
      ,[NSS]
      ,[FechaIngreso]
      ,[Foto]
       ,Empresa.[IdEmpresa]
	  ,Empresa.[Nombre] AS NombreEmpresa
  FROM [Empleado]
  INNER JOIN Empresa ON Empleado.IdEmpresa = Empresa.IdEmpresa
  WHERE Empleado.[NumeroEmpleado] = @NumeroEmpleado
GO

SELECT * FROM Usuario

ALTER PROCEDURE EmpleadoUpdate 
@NumeroEmpleado VARCHAR(50),
@RFC VARCHAR(20),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(254),
@FechaNacimiento DATE,
@NSS VARCHAR(20),
@FechaIngreso DATE,
@Foto VARCHAR(MAX),
@IdEmpresa INT

AS
	UPDATE [dbo].[Empleado]
   SET [RFC] = @RFC
      ,[Nombre] = @Nombre
      ,[ApellidoPaterno] = @ApellidoPaterno
      ,[ApellidoMaterno] = @ApellidoMaterno
      ,[Email] = @Email
      ,[FechaNacimiento] = CONVERT(DATE, @FechaNacimiento,105)
      ,[NSS] = @NSS
      ,[FechaIngreso] = CONVERT(DATE, @FechaNacimiento,105)
      ,[Foto] = @Foto
      ,[IdEmpresa] = @IdEmpresa
	WHERE Empleado.[NumeroEmpleado] = @NumeroEmpleado
GO

EmpleadoUpdate '103','YASS897456','Yael','Flores','Fuentes','yaelflores@gmail.com','11/10/1999','8892582','10/10/2014','','2'
select * from Empleado

CREATE PROCEDURE EmpleadoDelete
@NumeroEmpleado VARCHAR(50)
AS
	DELETE FROM [Empleado]
      WHERE Empleado.[NumeroEmpleado] = @NumeroEmpleado
GO

CREATE TABLE DependienteTipo
(
	IdDependienteTipo INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)

CREATE TABLE Dependiente
(
	IdDependiente INT IDENTITY(1,1) PRIMARY KEY,
	NumeroEmpleado VARCHAR(50),
	Nombre VARCHAR(50) NOT NULL,
	ApellidoPaterno VARCHAR(50) NOT NULL,
	ApellidoMaterno VARCHAR(50) NULL,
	FechaNacimiento DATE NULL,
	EstadoCivil VARCHAR(20),
	Genero CHAR(2),
	Telefono VARCHAR(20),
	RFC VARCHAR(20),
	IdDependienteTipo INT
	CONSTRAINT FK_DependienteOrder FOREIGN KEY (NumeroEmpleado)
    REFERENCES Empleado(NumeroEmpleado),
	CONSTRAINT FK_Dependiente1Order FOREIGN KEY (IdDependienteTipo)
    REFERENCES DependienteTipo(IdDependienteTipo)
)
GO

ALTER PROCEDURE DependienteTipoGetAll
AS
	SELECT [IdDependienteTipo]
      ,[Nombre]
  FROM [DependienteTipo]
GO

ALTER PROCEDURE DependienteAdd 
@NumeroEmpleado VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento DATE,
@EstadoCivil VARCHAR(20),
@Genero CHAR(2),
@Telefono VARCHAR(20),
@RFC VARCHAR(20),
@IdDependienteTipo INT
AS
	INSERT INTO [Dependiente]
           ([NumeroEmpleado]
           ,[Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno]
           ,[FechaNacimiento]
           ,[EstadoCivil]
           ,[Genero]
           ,[Telefono]
           ,[RFC]
           ,[IdDependienteTipo])
     VALUES
           (@NumeroEmpleado
           ,@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno
           , CONVERT(DATE, @FechaNacimiento,105)
           ,@EstadoCivil
           ,@Genero
           ,@Telefono
           ,@RFC
           ,@IdDependienteTipo)
GO

ALTER PROCEDURE DependienteGetAll
AS
	SELECT [IdDependiente]
      ,Empleado.[NumeroEmpleado]
	  ,Empleado.[Nombre] AS NombreEmpleado
      ,Dependiente.[Nombre]
      ,Dependiente.[ApellidoPaterno]
      ,Dependiente.[ApellidoMaterno]
      ,Dependiente.[FechaNacimiento]
      ,[EstadoCivil]
      ,[Genero]
      ,Dependiente.[Telefono]
      ,Dependiente.[RFC]
      ,DependienteTipo.[IdDependienteTipo]
	  ,DependienteTipo.[Nombre] AS NombreDespendienteTipo
  FROM [dbo].[Dependiente]
  INNER JOIN Empleado ON Dependiente.NumeroEmpleado = Empleado.NumeroEmpleado
  INNER JOIN DependienteTipo ON Dependiente.IdDependienteTipo = DependienteTipo.IdDependienteTipo
GO


CREATE PROCEDURE DependienteGetByIdEmpleado
@NumeroEmpleado VARCHAR(50)
AS
	SELECT [IdDependiente]
      ,Empleado.[NumeroEmpleado]
	  ,Empleado.[Nombre] AS NombreEmpleado
      ,Dependiente.[Nombre]
      ,Dependiente.[ApellidoPaterno]
      ,Dependiente.[ApellidoMaterno]
      ,Dependiente.[FechaNacimiento]
      ,[EstadoCivil]
      ,[Genero]
      ,Dependiente.[Telefono]
      ,Dependiente.[RFC]
      ,DependienteTipo.[IdDependienteTipo]
	  ,DependienteTipo.[Nombre] AS NombreDespendienteTipo
  FROM [dbo].[Dependiente]
  INNER JOIN Empleado ON Dependiente.NumeroEmpleado = Empleado.NumeroEmpleado
  INNER JOIN DependienteTipo ON Dependiente.IdDependienteTipo = DependienteTipo.IdDependienteTipo
  WHERE Dependiente.[NumeroEmpleado] = @NumeroEmpleado
GO

ALTER PROCEDURE DependienteGetById
@IdDependiente INT
AS
	SELECT [IdDependiente]
      ,Empleado.[NumeroEmpleado]
	  ,Empleado.[Nombre] AS NombreEmpleado
      ,Dependiente.[Nombre]
      ,Dependiente.[ApellidoPaterno]
      ,Dependiente.[ApellidoMaterno]
      ,Dependiente.[FechaNacimiento]
      ,[EstadoCivil]
      ,[Genero]
      ,Dependiente.[Telefono]
      ,Dependiente.[RFC]
      ,DependienteTipo.[IdDependienteTipo]
	  ,DependienteTipo.[Nombre] AS NombreDespendienteTipo
  FROM [dbo].[Dependiente]
  INNER JOIN Empleado ON Dependiente.NumeroEmpleado = Empleado.NumeroEmpleado
  INNER JOIN DependienteTipo ON Dependiente.IdDependienteTipo = DependienteTipo.IdDependienteTipo
  WHERE Dependiente.[IdDependiente] = @IdDependiente
GO

CREATE PROCEDURE DependienteUpdate 
@IdDependiente INT,
@NumeroEmpleado VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@FechaNacimiento DATE,
@EstadoCivil VARCHAR(20),
@Genero CHAR(2),
@Telefono VARCHAR(20),
@RFC VARCHAR(20),
@IdDependienteTipo INT
AS
	UPDATE [Dependiente]
	   SET [NumeroEmpleado] = @NumeroEmpleado
		  ,[Nombre] = @Nombre
		  ,[ApellidoPaterno] = @ApellidoPaterno
		  ,[ApellidoMaterno] = @ApellidoMaterno
		  ,[FechaNacimiento] = CONVERT(DATE, @FechaNacimiento,105)
		  ,[EstadoCivil] = @EstadoCivil
		  ,[Genero] = @Genero
		  ,[Telefono] = @Telefono
		  ,[RFC] = @RFC
		  ,[IdDependienteTipo] = @IdDependienteTipo
	 WHERE IdDependiente = @IdDependiente
GO

CREATE PROCEDURE DependienteDelete
@IdDependiente INT
AS
	DELETE FROM [Dependiente]
		  WHERE IdDependiente = @IdDependiente
GO

SELECT * FROM Aseguradora