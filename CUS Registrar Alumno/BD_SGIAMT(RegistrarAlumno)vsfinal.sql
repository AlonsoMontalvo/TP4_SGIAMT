create database [BD_SGIAMTvsRegistrarAlumno]

USE [BD_SGIAMTvsRegistrarAlumno]
GO
/****** Object:  Table [dbo].[T_Categoría]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Categoría](
	[PK_IC_Id] [int] NOT NULL,
	[VC_NombreCat] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_E_Categoría2] PRIMARY KEY CLUSTERED 
(
	[PK_IC_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Distrito]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Distrito](
	[PK_IDI_Cod] [int] NOT NULL,
	[VDI_NombreDis] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_E_Distrito5] PRIMARY KEY CLUSTERED 
(
	[PK_IDI_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Nivel]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Nivel](
	[PK_IN_Cod] [int] NOT NULL,
	[VN_NombreNivel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_E_Nivel7] PRIMARY KEY CLUSTERED 
(
	[PK_IN_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_NivelxTipoNivel]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_NivelxTipoNivel](
	[PK_INTN_Cod] [int] IDENTITY(1,1) NOT NULL,
	[FK_IN_Cod] [int] NOT NULL,
	[FK_ITN_Cod] [int] NOT NULL,
	[Nro_Alumno] [int] NOT NULL,
	[FK_IU_Dni] [int] NOT NULL,
 CONSTRAINT [PK_E_NivelxTipoNivel_1] PRIMARY KEY CLUSTERED 
(
	[PK_INTN_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_TipoNivel]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_TipoNivel](
	[PK_ITN_Cod] [int] NOT NULL,
	[ITN_NombreTipoNivel] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_E_TipoNivel8] PRIMARY KEY CLUSTERED 
(
	[PK_ITN_Cod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_TipoUsuario]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_TipoUsuario](
	[PK_ITU_TipoUsuario] [int] NOT NULL,
	[VTU_NombreTipoUsuario] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_E_TipoUsuario0] PRIMARY KEY CLUSTERED 
(
	[PK_ITU_TipoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 3/10/2019 05:23:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Usuario](
	[PK_IU_Dni] [int] NOT NULL,
	[VU_Nombre] [varchar](50) NOT NULL,
	[VU_APaterno] [varchar](50) NOT NULL,
	[VU_AMaterno] [varchar](50) NOT NULL,
	[VU_Celular] [int] NOT NULL,
	[VU_Correo] [varchar](50) NOT NULL,
	[VU_Direccion] [varchar](50) NOT NULL,
	[DU_FechaNacimiento] [date] NOT NULL,
	[VU_Sexo] [varchar](50) NOT NULL,
	[VU_Contraseña] [varchar](50) NOT NULL,
	[VU_Estado] [varchar](50) NOT NULL,
	[VU_Horario] [varchar](50) NOT NULL,
	[FK_ITU_TipoUsuario] [int] NOT NULL,
	[FK_IC_Id] [int] NOT NULL,
	[FK_IDI_Cod] [int] NOT NULL,
 CONSTRAINT [PK_T_E_Usuario3] PRIMARY KEY CLUSTERED 
(
	[PK_IU_Dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel]  WITH CHECK ADD  CONSTRAINT [FK_E_NivelxTipoNivel_E_Usuario] FOREIGN KEY([FK_IU_Dni])
REFERENCES [dbo].[T_Usuario] ([PK_IU_Dni])
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel] CHECK CONSTRAINT [FK_E_NivelxTipoNivel_E_Usuario]
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel]  WITH CHECK ADD  CONSTRAINT [FK_T_E_NivelxTipoNivel7] FOREIGN KEY([FK_ITN_Cod])
REFERENCES [dbo].[T_TipoNivel] ([PK_ITN_Cod])
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel] CHECK CONSTRAINT [FK_T_E_NivelxTipoNivel7]
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel]  WITH CHECK ADD  CONSTRAINT [FK_T_E_NivelxTipoNivel8] FOREIGN KEY([FK_IN_Cod])
REFERENCES [dbo].[T_Nivel] ([PK_IN_Cod])
GO
ALTER TABLE [dbo].[T_NivelxTipoNivel] CHECK CONSTRAINT [FK_T_E_NivelxTipoNivel8]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_E_Usuario_E_Distrito] FOREIGN KEY([FK_IDI_Cod])
REFERENCES [dbo].[T_Distrito] ([PK_IDI_Cod])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_E_Usuario_E_Distrito]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_E_Usuario0] FOREIGN KEY([FK_ITU_TipoUsuario])
REFERENCES [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_E_Usuario0]
GO
ALTER TABLE [dbo].[T_Usuario]  WITH CHECK ADD  CONSTRAINT [FK_T_E_Usuario2] FOREIGN KEY([FK_IC_Id])
REFERENCES [dbo].[T_Categoría] ([PK_IC_Id])
GO
ALTER TABLE [dbo].[T_Usuario] CHECK CONSTRAINT [FK_T_E_Usuario2]
GO



insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (1,'Ancón');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (2,'Ate Vitarte');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (3,'barranco');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (4,'breña');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (5,'chorrillo');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (6,'comas');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (7,'lima');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (8,'cieneguilla');

insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (1,'Categoria Pre-infantes');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (2,'Categoria Infantes');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (3,'Categoria Infantil');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (4,'Categoria Júnior');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (5,'Categoria Juvenil');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (6,'Categoria Adultos');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (7,'Categoria Senior');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (8,'Categoria Master');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (9,'Categoria Oro');
insert into [dbo].[T_Categoría] ([PK_IC_Id],[VC_NombreCat]) values (10,'no tiene categoria');

insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (1,'alumno');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (2,'secretaria');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (3,'profesor');

insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (1,'basico');
insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (2,'intermedio');
insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (3,'avanzado');

insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (1,'Pre-Infantil');
insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (2,'infantes');
insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (3,'Adulto');
