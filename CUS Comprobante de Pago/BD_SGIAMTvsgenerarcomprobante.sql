USE master;
GO
---------------
CREATE DATABASE [BD_SGIAMTvsgenerarcomprobante]
GO
USE [BD_SGIAMTvsgenerarcomprobante]
GO
ALTER AUTHORIZATION ON DATABASE::[BD_SGIAMTvsgenerarcomprobante] TO SA;
GO
CREATE TABLE [dbo].[T_Usuario](
	[PK_IU_Dni] [int] NOT NULL,
	[VU_Nombre] [varchar](50) NULL,
	[VU_APaterno] [varchar](50) NULL,
	[VU_AMaterno] [varchar](50) NULL,
	[VU_Celular] [int] NULL,
	[VU_Correo] [varchar](50) NULL,
	[VU_Direccion] [varchar](50) NULL,
	[DU_FechaNacimiento] [date] NULL,
	[VU_Sexo] [varchar](50) NULL,
	[VU_Contraseña] [varchar](50) NULL,
	[VU_Estado] [varchar](50) NULL,
	[VU_Horario] [varchar](50) NULL,
);
GO
CREATE TABLE [dbo].[T_Concepto_Pago](
	[PK_ICP_Id] [int] NOT NULL IDENTITY(1,1),
	[VCP_Descripcion] [varchar](50) NULL,
	[VCP_Monto] [decimal](5,2) NULL,
);
GO
CREATE TABLE [dbo].[T_Pago](
	[PK_IP_Id] [int] NOT NULL IDENTITY(1,1),
	[VP_Fecha] [date] NULL,
	[VP_Monto] [decimal](5,2) NULL,
	[VP_Año] [int] NULL,
	[VP_Mes] [varchar](50) NULL,
	[VP_Estado] [varchar](50) NULL,
	[FK_IU_Dni] [int] NULL,
	[FK_ICP_Id] [int] NULL,
);
GO
CREATE TABLE [dbo].[T_Comprobante_Pago](
	[PK_ICP_Id] [int] NOT NULL IDENTITY(1,1),
	[VCP_Nombre] [varchar](50) NULL,
	[VCP_APaterno] [varchar](50) NULL,
	[VCP_AMaterno] [varchar](50) NULL,
	[VCP_Monto] [decimal](5,2) NULL,
	[VCP_Fecha] [date] NULL,
	[VCP_Pdf] [varbinary](MAX) NULL,
	[FK_IP_Id] [int] NULL,
);
GO
ALTER TABLE [dbo].[T_Usuario] ADD PRIMARY KEY ([PK_IU_Dni]);
GO
ALTER TABLE [dbo].[T_Concepto_Pago] ADD PRIMARY KEY ([PK_ICP_Id]);
GO
ALTER TABLE [dbo].[T_Pago] ADD PRIMARY KEY ([PK_IP_Id]);
GO
ALTER TABLE [dbo].[T_Pago] ADD  FOREIGN KEY ([FK_IU_Dni]) REFERENCES [dbo].[T_Usuario]([PK_IU_Dni]);
GO
ALTER TABLE [dbo].[T_Pago] ADD  FOREIGN KEY ([FK_ICP_Id]) REFERENCES [dbo].[T_Concepto_Pago]([PK_ICP_Id]);
GO
ALTER TABLE [dbo].[T_Comprobante_Pago] ADD PRIMARY KEY ([PK_ICP_Id]);
GO
ALTER TABLE [dbo].[T_Comprobante_Pago] ADD  FOREIGN KEY ([FK_IP_Id]) REFERENCES [dbo].[T_Pago]([PK_IP_Id]);
GO
--REGISTROS-PARA HACER LAS PRUEBAS-LAS FECHAS ESTAN EN INGLES, CAMBIARLAS
INSERT INTO [dbo].[T_Concepto_Pago] ([VCP_Descripcion],[VCP_Monto]) VALUES ('PAGO TOTAL',110.00);
INSERT INTO [dbo].[T_Usuario] ([PK_IU_Dni],[VU_Nombre],[VU_APaterno],[VU_AMaterno],[VU_Celular],[VU_Correo],[VU_Direccion],[DU_FechaNacimiento],[VU_Sexo],[VU_Contraseña],[VU_Estado],[VU_Horario]) VALUES (18635870,'Alvera','Gebhard','Pickthorne',984324001,'correo','coricancha 745 zarate','1997-01-01','masculino','holamundo','inactivo','4:00-5:00 pm');
INSERT INTO [dbo].[T_Pago] ([VP_Fecha],[VP_Monto],[VP_Año],[VP_Mes],[VP_Estado],[FK_IU_Dni],[FK_ICP_Id]) VALUES ('01-01-2000',110.00,2019,'ENERO','FINALIZADO',18635870,1);
--
SELECT * FROM [dbo].[T_Usuario];
SELECT * FROM [dbo].[T_Pago];
SELECT * FROM [dbo].[T_Comprobante_Pago];
