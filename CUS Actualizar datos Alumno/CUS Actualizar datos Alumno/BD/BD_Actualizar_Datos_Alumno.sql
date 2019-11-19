create database [BD_SGIAMTvsActualizar_Datos_Alumno]
USE [BD_SGIAMTvsActualizar_Datos_Alumno]
GO
/****** Object:  Table [dbo].[T_Categoría]    Script Date: 14/11/2019 12:40:12 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[T_Distrito]    Script Date: 14/11/2019 12:40:12 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[T_TipoUsuario]    Script Date: 14/11/2019 12:40:12 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 14/11/2019 12:40:12 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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

insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (1,'alumno');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (2,'secretaria');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (3,'profesor');


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

INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (12478936, N'Luis', N'Huaman', N'Noa', 458965778, N'luis_huaman@gmail.com', N'Av.Lima', CAST(N'1996-08-07' AS Date), N'Masculino', N'54878', N'Activo', N'9:00 a 10:00', 1,3,2)
INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (46589475, N'Flor', N'Loayza', N'Ramos', 213697574, N'flore@hotmail.com', N'Av.Perú', CAST(N'1996-08-13' AS Date), N'Femenino', N'15248', N'Activo', N'9:00 a 10:00', 1,5,4)
INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (54897854, N'Carlos', N'Mendoza', N'Palo', 498651217, N'carlos_98@gmail.com', N'Av.Chorrillos', CAST(N'1997-12-27' AS Date), N'Masculino', N'45665', N'Activo', N'9:00 a 10:00', 1,3,3)
INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (54986253, N'Milagros', N'Cueche', N'Quispe', 930874001, N'mili_98@gmail.com', N'Av.Lima', CAST(N'1998-10-20' AS Date), N'Femenino', N'12345', N'Activo', N'9:00 a 10:00', 1,4,4)


select * from T_Usuario

select * from T_TipoUsuario

select * from T_Distrito

select * from T_Categoría