USE [master]
GO
/****** Object:  Database [JAvilesPT]    Script Date: 12/9/2022 4:45:24 PM ******/
CREATE DATABASE [JAvilesPT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JAvilesPT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JAvilesPT.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'JAvilesPT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\JAvilesPT_log.ldf' , SIZE = 784KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [JAvilesPT] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JAvilesPT].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JAvilesPT] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JAvilesPT] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JAvilesPT] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JAvilesPT] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JAvilesPT] SET ARITHABORT OFF 
GO
ALTER DATABASE [JAvilesPT] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JAvilesPT] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [JAvilesPT] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JAvilesPT] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JAvilesPT] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JAvilesPT] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JAvilesPT] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JAvilesPT] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JAvilesPT] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JAvilesPT] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JAvilesPT] SET  ENABLE_BROKER 
GO
ALTER DATABASE [JAvilesPT] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JAvilesPT] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JAvilesPT] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JAvilesPT] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JAvilesPT] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JAvilesPT] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JAvilesPT] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JAvilesPT] SET RECOVERY FULL 
GO
ALTER DATABASE [JAvilesPT] SET  MULTI_USER 
GO
ALTER DATABASE [JAvilesPT] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JAvilesPT] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JAvilesPT] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JAvilesPT] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'JAvilesPT', N'ON'
GO
USE [JAvilesPT]
GO
/****** Object:  StoredProcedure [dbo].[AddLibro]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddLibro](
@Nombre varchar(50),
@IdAutor int,
@NumeroPaginas int,
@FechaPublicacion date,
@IdEditorial int,
@Edicion varchar(50),
@IdGenero int)
as 
Insert into Libro(Nombre,
IdAutor,
NumeroPaginas,
FechaPublicacion,
IdEditorial,
Edicion,
IdGenero)
Values(
@Nombre,@IdAutor,@NumeroPaginas,CONVERT(date,@FechaPublicacion,105),
@IdEditorial,@Edicion,@IdGenero)
GO
/****** Object:  StoredProcedure [dbo].[LibroDelete]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[LibroDelete]
@IdLibro int
as 
delete from Libro
where Libro.IdLibro=@IdLibro

GO
/****** Object:  StoredProcedure [dbo].[LibroGetAll]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[LibroGetAll]
as 
select
Libro.IdLibro,
Libro.Nombre,
Autor.IdAutor,
Libro.NumeroPaginas,
Libro.FechaPublicacion,
Editorial.IdEditorial,
Libro.Edicion,
Genero.IdGenero
from Libro

Inner join Autor On Libro.IdAutor = Autor.IdAutor
Inner join Editorial On Libro.IdEditorial = Editorial.IdEditorial
Inner join Genero On Libro.IdGenero = Genero.IdGenero

GO
/****** Object:  StoredProcedure [dbo].[LibroGetById]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure  [dbo].[LibroGetById]
@IdLibro int
as 
select
Libro.IdLibro,
Libro.Nombre,
Autor.IdAutor,
Libro.NumeroPaginas,
Libro.FechaPublicacion,
Editorial.IdEditorial,
Libro.Edicion,
Genero.IdGenero
from Libro

Inner join Autor On Libro.IdAutor = Autor.IdAutor
Inner join Editorial On Libro.IdEditorial = Editorial.IdEditorial
Inner join Genero On Libro.IdGenero = Genero.IdGenero

where Libro.IdLibro=@IdLibro

GO
/****** Object:  StoredProcedure [dbo].[UpdateLibro]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[UpdateLibro](
@IdLibro int,
@Nombre varchar(50),
@IdAutor int,
@NumeroPaginas int,
@FechaPublicacion date,
@IdEditorial int,
@Edicion varchar(50),
@IdGenero int)
as 
Insert into Libro
(IdLibro,
Nombre,
IdAutor,
NumeroPaginas,
FechaPublicacion,
IdEditorial,
Edicion,
IdGenero)Values(
@IdAutor,@Nombre,@IdAutor,@NumeroPaginas,
@FechaPublicacion,@IdEditorial,
@Edicion,
@IdGenero
)
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Genero](
	[IdGenero] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 12/9/2022 4:45:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdAutor] [int] NULL,
	[NumeroPaginas] [int] NULL,
	[FechaPublicacion] [date] NULL,
	[IdEditorial] [int] NULL,
	[Edicion] [varchar](50) NULL,
	[IdGenero] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdAutor])
REFERENCES [dbo].[Autor] ([IdAutor])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdEditorial])
REFERENCES [dbo].[Editorial] ([IdEditorial])
GO
ALTER TABLE [dbo].[Libro]  WITH CHECK ADD FOREIGN KEY([IdGenero])
REFERENCES [dbo].[Genero] ([IdGenero])
GO
USE [master]
GO
ALTER DATABASE [JAvilesPT] SET  READ_WRITE 
GO
