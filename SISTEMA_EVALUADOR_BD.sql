USE [master]
GO
/****** Object:  Database [SISTEMA_EVALUADOR]    Script Date: 14/02/2016 05:08:25 p.m. ******/
CREATE DATABASE [SISTEMA_EVALUADOR]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SISTEMA_EVALUADOR', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SISTEMA_EVALUADOR.mdf' , SIZE = 4288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SISTEMA_EVALUADOR_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SISTEMA_EVALUADOR_log.ldf' , SIZE = 1072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SISTEMA_EVALUADOR].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ARITHABORT OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET RECOVERY FULL 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET  MULTI_USER 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SISTEMA_EVALUADOR', N'ON'
GO
USE [SISTEMA_EVALUADOR]
GO
/****** Object:  Table [dbo].[DEPARTAMENTOS]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPARTAMENTOS](
	[ID_DEPTO] [int] IDENTITY(1,1) NOT NULL,
	[NOMBRE] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_DEPTO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [uc_DepNombre] UNIQUE NONCLUSTERED 
(
	[NOMBRE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPENDIENTES]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPENDIENTES](
	[ID_DEPENDIENTE] [int] IDENTITY(1,1) NOT NULL,
	[ID_EMPLEADO] [int] NOT NULL,
	[NOMBRE] [varchar](100) NULL,
	[PARENTESCO] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_DEPENDIENTE] ASC,
	[ID_EMPLEADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLEADOS]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLEADOS](
	[ID_EMPLEADO] [int] IDENTITY(1,1) NOT NULL,
	[ID_JEFE] [int] NULL,
	[ID_DEPTO] [int] NOT NULL,
	[NOMBRES] [varchar](100) NULL,
	[APELLIDOS] [varchar](100) NULL,
	[DIRECCION] [varchar](100) NULL,
	[ESTADO_CIVIL] [char](1) NULL,
	[NIVEL_EDUCACIONAL] [varchar](100) NULL,
	[PUESTO] [varchar](100) NULL,
	[ANTECEDENTES] [char](1) NULL,
	[TELEFONO] [int] NULL,
	[FECHA_INGRESO] [date] NULL,
	[GENERO] [char](1) NULL,
	[IDENTIDAD] [varchar](80) NULL,
	[ACTIVO] [bit] NOT NULL CONSTRAINT [df_EmpActivo]  DEFAULT ((1)),
	[RAZON_DESPIDO] [varchar](500) NULL,
 CONSTRAINT [PK__EMPLEADO__922CA26963653DE2] PRIMARY KEY CLUSTERED 
(
	[ID_EMPLEADO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EVALUACION]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EVALUACION](
	[ID_EVAL] [int] IDENTITY(1,1) NOT NULL,
	[ID_EMPLEADO] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[fecha_evaluacion] [date] NOT NULL,
	[resultado] [float] NOT NULL,
 CONSTRAINT [PK__EVALUACI__A6E0618A2A82BF25] PRIMARY KEY CLUSTERED 
(
	[ID_EVAL] ASC,
	[ID_EMPLEADO] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GRADOS]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GRADOS](
	[ID_GRADO] [int] IDENTITY(1,1) NOT NULL,
	[ID_IND] [int] NOT NULL,
	[ID] [int] NOT NULL,
	[NOMBRE] [varchar](100) NULL,
	[VALOR] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_GRADO] ASC,
	[ID_IND] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INDICADORES]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INDICADORES](
	[ID_IND] [int] IDENTITY(1,1) NOT NULL,
	[ID] [int] NOT NULL,
	[INDICADORES_ID] [int] NULL,
	[ID_GEN] [int] NULL,
	[NOMBRE] [varchar](100) NULL,
	[PESO] [float] NULL,
 CONSTRAINT [PK__INDICADO__4F5D0AF8F32D3ECE] PRIMARY KEY CLUSTERED 
(
	[ID_IND] ASC,
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INFORME_INDICADORES]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INFORME_INDICADORES](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FECHA] [date] NULL,
	[NOMBRE] [varchar](50) NULL,
	[evalParaEmp] [bit] NOT NULL,
	[ID_DEPTO] [int] NULL,
	[ID_EMPLEADO] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[v_EmpleadosActivos]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_EmpleadosActivos]
AS
SELECT ID_EMPLEADO AS ID_EMP, CONCAT(NOMBRES, ' ', APELLIDOS) AS NOMBRE, ACTIVO FROM EMPLEADOS WHERE ACTIVO = '1'


GO
/****** Object:  View [dbo].[v_EmpleadosTodos]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[v_EmpleadosTodos]
AS
SELECT ID_EMPLEADO AS ID_EMP, CONCAT(NOMBRES, ' ', APELLIDOS) AS NOMBRE, ACTIVO FROM EMPLEADOS
GO
ALTER TABLE [dbo].[DEPENDIENTES]  WITH CHECK ADD  CONSTRAINT [FK__DEPENDIEN__ID_EM__286302EC] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[DEPENDIENTES] CHECK CONSTRAINT [FK__DEPENDIEN__ID_EM__286302EC]
GO
ALTER TABLE [dbo].[EMPLEADOS]  WITH CHECK ADD  CONSTRAINT [FK__EMPLEADOS__ID_DE__182C9B23] FOREIGN KEY([ID_DEPTO])
REFERENCES [dbo].[DEPARTAMENTOS] ([ID_DEPTO])
GO
ALTER TABLE [dbo].[EMPLEADOS] CHECK CONSTRAINT [FK__EMPLEADOS__ID_DE__182C9B23]
GO
ALTER TABLE [dbo].[EMPLEADOS]  WITH CHECK ADD  CONSTRAINT [FK__EMPLEADOS__ID_JE__1920BF5C] FOREIGN KEY([ID_JEFE])
REFERENCES [dbo].[EMPLEADOS] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[EMPLEADOS] CHECK CONSTRAINT [FK__EMPLEADOS__ID_JE__1920BF5C]
GO
ALTER TABLE [dbo].[EVALUACION]  WITH CHECK ADD  CONSTRAINT [FK__EVALUACIO__ID_EM__1BFD2C07] FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID_EMPLEADO])
GO
ALTER TABLE [dbo].[EVALUACION] CHECK CONSTRAINT [FK__EVALUACIO__ID_EM__1BFD2C07]
GO
ALTER TABLE [dbo].[EVALUACION]  WITH CHECK ADD  CONSTRAINT [FK__EVALUACION__ID__1CF15040] FOREIGN KEY([ID])
REFERENCES [dbo].[INFORME_INDICADORES] ([ID])
GO
ALTER TABLE [dbo].[EVALUACION] CHECK CONSTRAINT [FK__EVALUACION__ID__1CF15040]
GO
ALTER TABLE [dbo].[GRADOS]  WITH CHECK ADD  CONSTRAINT [FK__GRADOS__1FCDBCEB] FOREIGN KEY([ID_IND], [ID])
REFERENCES [dbo].[INDICADORES] ([ID_IND], [ID])
GO
ALTER TABLE [dbo].[GRADOS] CHECK CONSTRAINT [FK__GRADOS__1FCDBCEB]
GO
ALTER TABLE [dbo].[INDICADORES]  WITH CHECK ADD  CONSTRAINT [FK__INDICADORES__145C0A3F] FOREIGN KEY([ID_GEN], [INDICADORES_ID])
REFERENCES [dbo].[INDICADORES] ([ID_IND], [ID])
GO
ALTER TABLE [dbo].[INDICADORES] CHECK CONSTRAINT [FK__INDICADORES__145C0A3F]
GO
ALTER TABLE [dbo].[INDICADORES]  WITH CHECK ADD  CONSTRAINT [FK__INDICADORES__ID__15502E78] FOREIGN KEY([ID])
REFERENCES [dbo].[INFORME_INDICADORES] ([ID])
GO
ALTER TABLE [dbo].[INDICADORES] CHECK CONSTRAINT [FK__INDICADORES__ID__15502E78]
GO
ALTER TABLE [dbo].[INFORME_INDICADORES]  WITH CHECK ADD FOREIGN KEY([ID_DEPTO])
REFERENCES [dbo].[DEPARTAMENTOS] ([ID_DEPTO])
GO
ALTER TABLE [dbo].[INFORME_INDICADORES]  WITH CHECK ADD FOREIGN KEY([ID_EMPLEADO])
REFERENCES [dbo].[EMPLEADOS] ([ID_EMPLEADO])
GO
/****** Object:  StoredProcedure [dbo].[CreateLoginAndUser]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE procedure [dbo].[CreateLoginAndUser](
        @login varchar(100),
        @password varchar(100))
as

declare @sql nvarchar(max)
set @sql = 'use ' + 'SISTEMA_EVALUADOR' + ';' +
           'create login ' + @login + 
               ' with password = ''' + @password + '''; ' +
           'create user ' + @login + ' from login ' + @login + ';'
exec (@sql)



GO
/****** Object:  StoredProcedure [dbo].[select_indicadores_con_generales]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[select_indicadores_con_generales] @id int
AS
	select i.*, gen.nombre as indicador_general, gen.PESO as peso_general  from INDICADORES i inner join INDICADORES gen on i.ID_GEN = 		gen.ID_IND
	where i.ID = @id
	



GO
/****** Object:  StoredProcedure [dbo].[select_indicadores_con_grados]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO


CREATE PROCEDURE [dbo].[select_indicadores_con_grados] @id int
AS
	select i.*,g.* from INDICADORES i left join GRADOS g on i.ID_IND = g.ID_IND 
	where i.ID = @id
	order by i.ID_IND asc




GO
/****** Object:  StoredProcedure [dbo].[SP_BORRAR_EVALUACION_BASE]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_BORRAR_EVALUACION_BASE]
@EvaluacionID int
AS
DELETE FROM EVALUACION WHERE ID = @EvaluacionID
DELETE FROM GRADOS WHERE ID = @EvaluacionID
DELETE FROM INDICADORES WHERE ID = @EvaluacionID
DELETE FROM INFORME_INDICADORES WHERE ID=@EvaluacionID

GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_DEPARTAMENTO]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_DELETE_DEPARTAMENTO] @ID_DEP INT
AS
BEGIN

  DELETE FROM DEPARTAMENTOS WHERE ID_DEPTO = @ID_DEP;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_DEPENDIENTES]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DELETE_DEPENDIENTES]
@ID_DEP INT,
@ID_EMPLEADO INT
AS
DELETE FROM [dbo].[DEPENDIENTES]
      WHERE @ID_DEP = ID_DEPENDIENTE AND @ID_EMPLEADO = ID_EMPLEADO;




GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_EMPLEADO]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_DELETE_EMPLEADO] @ID_EMP INT, @RAZON VARCHAR(500)
AS
BEGIN

  UPDATE EMPLEADOS SET ACTIVO = '0', RAZON_DESPIDO = @RAZON WHERE ID_EMPLEADO = @ID_EMP;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_EVALUACION]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[SP_DELETE_EVALUACION] @ID_EVAL INT, @ID_EMPLEADO INT, @ID INT
AS
BEGIN

  DELETE FROM EVALUACION WHERE ID_EVAL = @ID_EVAL AND ID_EMPLEADO = @ID_EMPLEADO AND ID = @ID;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_GRADO]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_DELETE_GRADO] @ID_GRADO INT, @ID_IND INT, @ID INT
AS
BEGIN

  DELETE FROM GRADOS WHERE ID_GRADO = @ID_GRADO AND @ID_IND = ID_IND AND @ID = ID;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_INDICADOR]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_DELETE_INDICADOR] @ID_IND INT, @ID INT
AS
BEGIN

  DELETE FROM INDICADORES WHERE @ID_IND = ID_IND AND @ID = ID;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_DELETE_INFORME]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_DELETE_INFORME] @ID INT
AS
BEGIN

  DELETE FROM INFORME_INDICADORES WHERE @ID = ID

END


GO
/****** Object:  StoredProcedure [dbo].[sp_department_average]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[sp_department_average] @department_id int, @eval_date date
AS
	select EVALUACION.resultado, EVALUACION.fecha_evaluacion from EVALUACION 
		inner join EMPLEADOS on EMPLEADOS.ID_EMPLEADO = EVALUACION.ID_EMPLEADO
	where EMPLEADOS.ID_DEPTO = @department_id AND EVALUACION.FECHA_EVALUACION = @eval_date


GO
/****** Object:  StoredProcedure [dbo].[sp_employee_results]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[sp_employee_results] @eval_date date, @id_empleado int
AS
	SELECT EVALUACION.RESULTADO FROM EVALUACION
	WHERE EVALUACION.fecha_evaluacion = @eval_date and ID_EMPLEADO = @id_empleado;


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_DEPARTAMENTO]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_INSERT_DEPARTAMENTO] @NOMBRE varchar(100)
AS
BEGIN

  INSERT INTO DEPARTAMENTOS(NOMBRE) VALUES(@NOMBRE);

END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_DEPENDIENTE]    Script Date: 14/02/2016 05:08:25 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_INSERT_DEPENDIENTE] @ID_EMPLEADO INT, @NOMBRE varchar(100),@PARENTESCO VARCHAR(100)
AS
BEGIN
  INSERT INTO DEPENDIENTES(ID_EMPLEADO,NOMBRE,PARENTESCO) VALUES(@ID_EMPLEADO,@NOMBRE,@PARENTESCO);
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_EMPLEADOS]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE proc [dbo].[SP_INSERT_EMPLEADOS]
@ID_JEFE INT,
@ID_DEPTO INT,
@NOMBRES varchar(100),
@APELLIDOS varchar(100),
@DIRECCION varchar(100),
@ESTADO_CIVIL char(1),
@NIVEL_EDUCACIONAL varchar(100),
@PUESTO varchar(100),
@ANTECEDENTES char(1),
@TELEFONO int,
@FECHA_INGRESO DATE,
@GENERO CHAR(1),
@N_IDENTIDAD VARCHAR(80)
AS
IF NOT EXISTS (SELECT * from EMPLEADOS where IDENTIDAD = @n_identidad)
BEGIN
	INSERT INTO [dbo].[EMPLEADOS]
           ([ID_JEFE]
           ,[ID_DEPTO]
           ,[NOMBRES]
           ,[APELLIDOS]
           ,[DIRECCION]
           ,[ESTADO_CIVIL]
           ,[NIVEL_EDUCACIONAL]
           ,[PUESTO],
		   [ANTECEDENTES],[TELEFONO],FECHA_INGRESO,GENERO,IDENTIDAD)
     VALUES 			  (@ID_JEFE,@ID_DEPTO,@NOMBRES,@APELLIDOS,@DIRECCION,@ESTADO_CIVIL,@NIVEL_EDUCACIONAL,@PUESTO,@ANTECEDENTES,@TELEFONO,@FECHA_INGRESO,@GENERO,@N_IDENTIDAD)
END

ELSE 
raiserror(N'Empleado Ya existe en el registro',16,10);




GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_EVALUACION]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_INSERT_EVALUACION] @ID_EMPLEADO INT, @ID INT,@FECHA_EVAL DATE, @RESUL FLOAT
AS
BEGIN
  INSERT INTO EVALUACION(ID_EMPLEADO, ID, fecha_evaluacion, resultado) VALUES( @ID_EMPLEADO, @ID,@FECHA_EVAL,@RESUL);
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_GRADO]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_INSERT_GRADO] @ID_IND INT,@ID INT, @NOMBRE varchar(100), @VALOR INT
AS
BEGIN
  INSERT INTO GRADOS(ID_IND,ID,NOMBRE,VALOR) VALUES( @ID_IND, @ID ,@NOMBRE ,@VALOR );
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_INDICADOR]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_INSERT_INDICADOR] @ID INT, @INDICADORES_ID INT, @ID_GEN INT, @NOMBRE VARCHAR(100), @PESO FLOAT
AS
BEGIN
  INSERT INTO INDICADORES(ID, INDICADORES_ID, ID_GEN, NOMBRE, PESO) VALUES( @ID ,@INDICADORES_ID ,@ID_GEN ,@NOMBRE ,@PESO);
END


GO
/****** Object:  StoredProcedure [dbo].[SP_INSERT_INFORME_INDICADORES]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_INSERT_INFORME_INDICADORES]
@FECHA DATE ,@NOMBRE VARCHAR(50)
AS
INSERT INTO INFORME_INDICADORES VALUES(@FECHA,@NOMBRE);


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_DEPTO]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_UPDATE_DEPTO]
@ID_DEPTO INT,
@NUEVON VARCHAR(100)
AS 
UPDATE DEPARTAMENTOS SET NOMBRE=@NUEVON WHERE ID_DEPTO = @ID_DEPTO;


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_EMPLEADO]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_UPDATE_EMPLEADO] @ID_EMP INT, @ID_JEFE INT, @ID_DEPTO INT, @NOMBRES varchar(100), @APELLIDOS varchar(100),
@DIRECCION varchar(100), @ESTADO_CIVIL char(1), @NIVEL_EDUCACIONAL varchar(100), @PUESTO varchar(100), @ANTECEDENTES char(1),
@TELEFONO INT, @NUM_ID varchar(100)
AS
BEGIN

  UPDATE EMPLEADOS SET ID_JEFE = @ID_JEFE , ID_DEPTO = @ID_DEPTO, NOMBRES = @NOMBRES, APELLIDOS = @APELLIDOS, DIRECCION = @DIRECCION,
  ESTADO_CIVIL = @ESTADO_CIVIL, NIVEL_EDUCACIONAL = @NIVEL_EDUCACIONAL, PUESTO = @PUESTO, ANTECEDENTES = @ANTECEDENTES, TELEFONO = @TELEFONO, IDENTIDAD = @NUM_ID WHERE ID_EMPLEADO = @ID_EMP;

END


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_GRADO]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_UPDATE_GRADO] @ID_GRADO INT, @ID_IND INT, @ID INT, @NOMBRE VARchar(100), @valor int
AS
BEGIN

  UPDATE GRADOS SET NOMBRE = @NOMBRE, VALOR = @VALOR WHERE ID_GRADO = @ID_GRADO AND ID_IND = @ID_IND AND ID = @ID

END


GO
/****** Object:  StoredProcedure [dbo].[SP_UPDATE_INDICADOR]    Script Date: 14/02/2016 05:08:26 p.m. ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROCEDURE [dbo].[SP_UPDATE_INDICADOR] ( @ID_IND INT, @NOMBRE varchar(100), @PESO FLOAT )
AS
BEGIN
	UPDATE INDICADORES SET NOMBRE = @NOMBRE, PESO = @PESO WHERE ID_IND = @ID_IND;
END


GO
USE [master]
GO
ALTER DATABASE [SISTEMA_EVALUADOR] SET  READ_WRITE 
GO
