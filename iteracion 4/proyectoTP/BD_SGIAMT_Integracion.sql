create database [BD_SGIAMTIntegracionfinal]
USE [BD_SGIAMTIntegracionfinal]
GO
/****** Object:  Table [dbo].[T_Asistencia]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Asistencia](
	[PK_IA_Asistencia] [int] IDENTITY(1,1) NOT NULL,
	[TA_Hora] [varchar](50) NOT NULL,
	[VA_EstadoAsistencia] [varchar](50) NOT NULL,
	[FK_IU_Dni] [int] NOT NULL,
	[FK_ISD_SemanaxDia] [int] NOT NULL,
 CONSTRAINT [PK_T_E_Asistencia58] PRIMARY KEY CLUSTERED 
(
	[PK_IA_Asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Categoría]    Script Date: 21/11/2019 03:38:43 am ******/
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
/****** Object:  Table [dbo].[T_Comprobante_Pago]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Comprobante_Pago](
	[PK_ICP_Id] [int] IDENTITY(1,1) NOT NULL,
	[VCP_Fecha] [date] NULL,
	[VCP_Nombre] [varchar](50) NULL,
	[VCP_APaterno] [varchar](50) NULL,
	[VCP_AMaterno] [varchar](50) NULL,
	[VCP_Concepto] [varchar](50) NULL,
	[VCP_Monto] [decimal](5, 2) NULL,
	[VCP_Año] [int] NULL,
	[VCP_Mes] [varchar](50) NULL,
	[VCP_Documento] [varbinary](max) NULL,
	[FK_IP_Id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PK_ICP_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Concepto_Pago]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Concepto_Pago](
	[PK_ICP_Id] [int] IDENTITY(1,1) NOT NULL,
	[VCP_Descripcion] [varchar](50) NULL,
	[VCP_Monto] [decimal](5, 2) NULL,
 CONSTRAINT [PK__T_Concep__9628763E3C26523C] PRIMARY KEY CLUSTERED 
(
	[PK_ICP_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Dia]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Dia](
	[PK_ID_Dia] [int] NOT NULL,
	[VD_NombreDia] [varchar](50) NOT NULL,
 CONSTRAINT [PK_T_Dia] PRIMARY KEY CLUSTERED 
(
	[PK_ID_Dia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Distrito]    Script Date: 21/11/2019 03:38:43 am ******/
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
/****** Object:  Table [dbo].[T_Nivel]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[T_NivelxTipoNivel]    Script Date: 21/11/2019 03:38:43 am ******/
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
/****** Object:  Table [dbo].[T_Pago]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Pago](
	[PK_IP_Id] [int] IDENTITY(1,1) NOT NULL,
	[VP_Fecha] [date] NULL,
	[VP_Monto] [decimal](5, 2) NULL,
	[VP_Año] [int] NULL,
	[VP_Mes] [varchar](50) NULL,
	[VP_Estado] [varchar](50) NULL,
	[FK_IU_Dni] [int] NULL,
	[FK_ICP_Id] [int] NULL,
 CONSTRAINT [PK__T_Pago__3A4733D765B4E8B0] PRIMARY KEY CLUSTERED 
(
	[PK_IP_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Progreso]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Progreso](
	[PK_IP_Progreso] [int] IDENTITY(1,1) NOT NULL,
	[VP_NombreProgreso] [varchar](50) NOT NULL,
	[DP_NotaPasos] [int] NOT NULL,
	[DP_NotaTecnica] [int] NOT NULL,
	[DP_NotaInteres] [int] NOT NULL,
	[DP_NotaHabilidad] [int] NOT NULL,
	[DP_TotalNota] [decimal](5, 2) NOT NULL,
	[VP_Observacion] [varchar](250) NOT NULL,
	[FK_IU_Dni] [int] NOT NULL,
	[FK_ISD_SemanaxDia] [int] NOT NULL,
 CONSTRAINT [PK_IP_Progreso58] PRIMARY KEY CLUSTERED 
(
	[PK_IP_Progreso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_Semana]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Semana](
	[PK_IS_Semana] [int] NOT NULL,
	[VS_NombreSemana] [nchar](50) NOT NULL,
 CONSTRAINT [PK_T_Semana] PRIMARY KEY CLUSTERED 
(
	[PK_IS_Semana] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_SemanaxDia]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SemanaxDia](
	[PK_ISD_SemanaxDia] [int] IDENTITY(1,1) NOT NULL,
	[FK_IS_Semana] [int] NOT NULL,
	[FK_ID_Dia] [int] NOT NULL,
 CONSTRAINT [PK_T_SemanaxDia] PRIMARY KEY CLUSTERED 
(
	[PK_ISD_SemanaxDia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[T_TipoNivel]    Script Date: 21/11/2019 03:38:43 am ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [dbo].[T_TipoUsuario]    Script Date: 21/11/2019 03:38:43 am ******/
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
/****** Object:  Table [dbo].[T_Usuario]    Script Date: 21/11/2019 03:38:43 am ******/
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
ALTER TABLE [dbo].[T_Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_T_Asistencia_T_SemanaxDia] FOREIGN KEY([FK_ISD_SemanaxDia])
REFERENCES [dbo].[T_SemanaxDia] ([PK_ISD_SemanaxDia])
GO
ALTER TABLE [dbo].[T_Asistencia] CHECK CONSTRAINT [FK_T_Asistencia_T_SemanaxDia]
GO
ALTER TABLE [dbo].[T_Asistencia]  WITH CHECK ADD  CONSTRAINT [FK_T_Asistencia_T_Usuario] FOREIGN KEY([FK_IU_Dni])
REFERENCES [dbo].[T_Usuario] ([PK_IU_Dni])
GO
ALTER TABLE [dbo].[T_Asistencia] CHECK CONSTRAINT [FK_T_Asistencia_T_Usuario]
GO
ALTER TABLE [dbo].[T_Comprobante_Pago]  WITH CHECK ADD FOREIGN KEY([FK_IP_Id])
REFERENCES [dbo].[T_Pago] ([PK_IP_Id])
GO
ALTER TABLE [dbo].[T_Comprobante_Pago]  WITH CHECK ADD FOREIGN KEY([FK_IP_Id])
REFERENCES [dbo].[T_Pago] ([PK_IP_Id])
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
ALTER TABLE [dbo].[T_Pago]  WITH CHECK ADD  CONSTRAINT [FK__T_Pago__FK_ICP_I__4F7CD00D] FOREIGN KEY([FK_ICP_Id])
REFERENCES [dbo].[T_Concepto_Pago] ([PK_ICP_Id])
GO
ALTER TABLE [dbo].[T_Pago] CHECK CONSTRAINT [FK__T_Pago__FK_ICP_I__4F7CD00D]
GO
ALTER TABLE [dbo].[T_Pago]  WITH CHECK ADD  CONSTRAINT [FK__T_Pago__FK_IU_Dn__4E88ABD4] FOREIGN KEY([FK_IU_Dni])
REFERENCES [dbo].[T_Usuario] ([PK_IU_Dni])
GO
ALTER TABLE [dbo].[T_Pago] CHECK CONSTRAINT [FK__T_Pago__FK_IU_Dn__4E88ABD4]
GO
ALTER TABLE [dbo].[T_Progreso]  WITH CHECK ADD  CONSTRAINT [FK_T_Progreso_T_SemanaxDia] FOREIGN KEY([FK_ISD_SemanaxDia])
REFERENCES [dbo].[T_SemanaxDia] ([PK_ISD_SemanaxDia])
GO
ALTER TABLE [dbo].[T_Progreso] CHECK CONSTRAINT [FK_T_Progreso_T_SemanaxDia]
GO
ALTER TABLE [dbo].[T_Progreso]  WITH CHECK ADD  CONSTRAINT [FK_T_Progreso_T_Usuario] FOREIGN KEY([FK_IU_Dni])
REFERENCES [dbo].[T_Usuario] ([PK_IU_Dni])
GO
ALTER TABLE [dbo].[T_Progreso] CHECK CONSTRAINT [FK_T_Progreso_T_Usuario]
GO
ALTER TABLE [dbo].[T_SemanaxDia]  WITH CHECK ADD  CONSTRAINT [FK_T_SemanaxDia_T_Dia] FOREIGN KEY([FK_ID_Dia])
REFERENCES [dbo].[T_Dia] ([PK_ID_Dia])
GO
ALTER TABLE [dbo].[T_SemanaxDia] CHECK CONSTRAINT [FK_T_SemanaxDia_T_Dia]
GO
ALTER TABLE [dbo].[T_SemanaxDia]  WITH CHECK ADD  CONSTRAINT [FK_T_SemanaxDia_T_Semana] FOREIGN KEY([FK_IS_Semana])
REFERENCES [dbo].[T_Semana] ([PK_IS_Semana])
GO
ALTER TABLE [dbo].[T_SemanaxDia] CHECK CONSTRAINT [FK_T_SemanaxDia_T_Semana]
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



INSERT INTO [dbo].[T_Concepto_Pago] ([VCP_Descripcion],[VCP_Monto]) VALUES ('Pago Anual',30.00);
INSERT INTO [dbo].[T_Concepto_Pago] ([VCP_Descripcion],[VCP_Monto]) VALUES ('Pago Mensual',80.00);
INSERT INTO [dbo].[T_Concepto_Pago] ([VCP_Descripcion],[VCP_Monto]) VALUES ('Pago Total',110.00);

--INICIALIZADO DE DISTRITO

insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (1,'Ancón');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (2,'Ate Vitarte');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (3,'barranco');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (4,'breña');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (5,'chorrillo');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (6,'comas');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (7,'lima');
insert into [dbo].[T_Distrito] ([PK_IDI_Cod],[VDI_NombreDis]) values (8,'cieneguilla');

--INICIALIZADO DE Categoria

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

--INICIALIZADO DE Tipousuario

insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (1,'alumno');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (2,'recepcionista');
insert into [dbo].[T_TipoUsuario] ([PK_ITU_TipoUsuario],[VTU_NombreTipoUsuario]) values (3,'profesor');

--INICIALIZADO DE Nivel

insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (1,'basico');
insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (2,'intermedio');
insert into [dbo].[T_Nivel] ([PK_IN_Cod],[VN_NombreNivel]) values (3,'avanzado');

--INICIALIZADO DE Tipo de Nivel

insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (1,'Pre-Infantil');
insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (2,'infantes');
insert into [dbo].[T_TipoNivel] ([PK_ITN_Cod],[ITN_NombreTipoNivel]) values (3,'Adulto');

--INICIALIZADO DE DIA

INSERT [dbo].[T_Dia] ([PK_ID_Dia], [VD_NombreDia]) VALUES (1, N'Lunes')
INSERT [dbo].[T_Dia] ([PK_ID_Dia], [VD_NombreDia]) VALUES (2, N'Miércoles')
INSERT [dbo].[T_Dia] ([PK_ID_Dia], [VD_NombreDia]) VALUES (3, N'Viernes')

--INICIALIZADO DE SEMANA

INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (1, N'Semana 1')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (2, N'Semana 2')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (3, N'Semana 3')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (4, N'Semana 4')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (5, N'Semana 5')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (6, N'Semana 6')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (7, N'Semana 7')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (8, N'Semana 8')
INSERT [dbo].[T_Semana] ([PK_IS_Semana], [VS_NombreSemana]) VALUES (9, N'Semana 9')

--INICIALIZADO DE SEMANAXDIA

INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 1, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 1, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 1, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 2, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 2, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 2, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 3, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 3, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 3, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 4, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 4, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 4, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 5, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 5, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 5, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 6, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 6, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES (6, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 7, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 7, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 7, 3)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES ( 8, 1)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES (8, 2)
INSERT [dbo].[T_SemanaxDia] ( [FK_IS_Semana], [FK_ID_Dia]) VALUES  (8, 3)


INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (72223543, N'Flor', N'Loayza', N'Ramos', 213697574, N'recepcionista@hotmail.com', N'Av.Perú', CAST(N'1996-08-13' AS Date), N'Femenino', N'123', N'Activo', N'9:00 a 10:00', 2,10,5)
INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (72223544, N'Luis', N'Huaman', N'Noa', 458965778, N'profesor@hotmail.com', N'Av.Lima', CAST(N'1996-08-07' AS Date), N'Masculino', N'123', N'Activo', N'9:00 a 10:00', 3,10,2)
INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (72223546, N'Luis', N'Huaman', N'Noa', 458965778, N'profesor@hotmail.com', N'Av.Lima', CAST(N'1996-08-07' AS Date), N'Masculino', N'123', N'Activo', N'9:00 a 10:00', 1,10,2)

INSERT [dbo].[T_Usuario] ([PK_IU_Dni], [VU_Nombre], [VU_APaterno], [VU_AMaterno], [VU_Celular], [VU_Correo], [VU_Direccion], [DU_FechaNacimiento], [VU_Sexo], [VU_Contraseña], [VU_Estado], [VU_Horario], [FK_ITU_TipoUsuario], [FK_IC_Id], [FK_IDI_Cod]) VALUES (72223545, N'Luis', N'Huaman', N'Noa', 458965778, N'profesor@hotmail.com', N'Av.Lima', CAST(N'1996-08-07' AS Date), N'Masculino', N'123', N'Activo', N'9:00 a 10:00', 1,10,2)

select * from T_Usuario