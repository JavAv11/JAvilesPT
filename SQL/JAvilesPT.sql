USE [master]
GO
/****** Object:  Database [JAvilesPT]    Script Date: 12/12/2022 12:21:42 a. m. ******/
CREATE DATABASE [JAvilesPT]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JAvilesPT', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JAvilesPT.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JAvilesPT_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JAvilesPT_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
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
ALTER DATABASE [JAvilesPT] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JAvilesPT] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JAvilesPT', N'ON'
GO
ALTER DATABASE [JAvilesPT] SET QUERY_STORE = OFF
GO
USE [JAvilesPT]
GO
/****** Object:  Table [dbo].[Autor]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Autor](
	[IdAutor] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdAutor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editorial]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Editorial](
	[IdEditorial] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdEditorial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genero]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genero](
	[IdGenero] [int] NOT NULL,
	[Nombre] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IdGenero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Libro]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Libro](
	[IdLibro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[IdAutor] [int] NULL,
	[NumeroPaginas] [int] NULL,
	[FechaPublicacion] [varchar](50) NULL,
	[IdEditorial] [int] NULL,
	[Edicion] [varchar](50) NULL,
	[IdGenero] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[AddLibro]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddLibro](
@Nombre varchar(50),
@IdAutor int,
@NumeroPaginas int,
@FechaPublicacion varchar(50),
@IdEditorial int,
@Edicion varchar(50),
@IdGenero int)
as 
Insert into Libro(Nombre,
Autor.IdAutor,
NumeroPaginas,
FechaPublicacion,
Editorial.IdEditorial,
Edicion,
Genero.IdGenero)
Values(
@Nombre,@IdAutor,@NumeroPaginas,CONVERT(date,@FechaPublicacion,105),
@IdEditorial,@Edicion,@IdGenero)
GO
/****** Object:  StoredProcedure [dbo].[AutorGetAll]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[AutorGetAll]
as select
Autor.IdAutor,
Autor.Nombre as 'NombreAutor'
from Autor
GO
/****** Object:  StoredProcedure [dbo].[EditorialGetAll]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[EditorialGetAll]
as select
Editorial.IdEditorial,
Editorial.Nombre as 'NombreEditorial'
from Editorial
GO
/****** Object:  StoredProcedure [dbo].[GeneroGetAll]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[GeneroGetAll]
as select
Genero.IdGenero,
Genero.Nombre as 'NombreGenero'
from Genero
GO
/****** Object:  StoredProcedure [dbo].[LibroDelete]    Script Date: 12/12/2022 12:21:42 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[LibroGetAll]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure  [dbo].[LibroGetAll]
as 
select
Libro.IdLibro,
Libro.Nombre,
Autor.IdAutor,
Autor.Nombre as 'NombreAutor',
Libro.NumeroPaginas,
Libro.FechaPublicacion,
Editorial.IdEditorial,
Editorial.Nombre as 'NombreEditorial',
Libro.Edicion,
Genero.IdGenero,
Genero.Nombre as 'NombreGenero'
from Libro

Inner join Autor On Libro.IdAutor = Autor.IdAutor
Inner join Editorial On Libro.IdEditorial = Editorial.IdEditorial
Inner join Genero On Libro.IdGenero = Genero.IdGenero

GO
/****** Object:  StoredProcedure [dbo].[LibroGetById]    Script Date: 12/12/2022 12:21:42 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateLibro]    Script Date: 12/12/2022 12:21:42 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[UpdateLibro](
@IdLibro int,
@Nombre varchar(50),
@IdAutor int,
@NumeroPaginas int,
@FechaPublicacion varchar(50),
@IdEditorial int,
@Edicion varchar(50),
@IdGenero int)
as 
Update Libro
set

Nombre=@Nombre,
IdAutor=@IdAutor,
NumeroPaginas=@NumeroPaginas,
FechaPublicacion=CONVERT(date,@FechaPublicacion,105),
IdEditorial=@IdEditorial,
Edicion=@Edicion,
IdGenero=@IdGenero

where IdLibro=@IdLibro


GO
USE [master]
GO
ALTER DATABASE [JAvilesPT] SET  READ_WRITE 
GO
