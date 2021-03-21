

USE [BTPAGC]

CREATE TABLE [dbo].[Estudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](60) NOT NULL,
	[FechaNacimiento] [datetime] NOT NULL,
 CONSTRAINT [PK_Estudiantes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]


CREATE TABLE [dbo].[Asignaciones](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](60) NOT NULL,
 CONSTRAINT [PK_Asignaciones] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[AsignacionesEstudiantes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDAsignacion] [int] NOT NULL,
	[IDEstudiante] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[AsignacionesEstudiantes]  WITH CHECK ADD  CONSTRAINT [fk_Asignaciones] FOREIGN KEY([IDAsignacion])
REFERENCES [dbo].[Asignaciones] ([ID])
GO

ALTER TABLE [dbo].[AsignacionesEstudiantes]  WITH CHECK ADD  CONSTRAINT [fk_Estudiantes] FOREIGN KEY([IDEstudiante])
REFERENCES [dbo].[Estudiantes] ([ID])
GO

SELECT [ID],[Nombre],[FechaNacimiento] FROM [BTPAGC].[dbo].[Estudiantes]
  
INSERT INTO [BTPAGC].[dbo].[Estudiantes] VALUES('Angel Gonzalez Chavez', '1972/11/24')
INSERT INTO [BTPAGC].[dbo].[Estudiantes] VALUES('Fermin Ortega Vazquez', '1980/03/15')

SELECT [ID],[Nombre] FROM [Pruebas].[dbo].[Asignaciones]

INSERT INTO [BTPAGC].[dbo].[Asignaciones] VALUES('Matematicas');
INSERT INTO [BTPAGC].[dbo].[Asignaciones] VALUES('Lectura');
INSERT INTO [BTPAGC].[dbo].[Asignaciones] VALUES('Ingles');
INSERT INTO [BTPAGC].[dbo].[Asignaciones] VALUES('Civismo');

SELECT [ID],[IDAsignacion],[IDEstudiante] FROM [BTPAGC].[dbo].[AsignacionesEstudiantes]

INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(1,1);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(2,1);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(3,1);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(4,1);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(1,2);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(3,2);
INSERT INTO [BTPAGC].[dbo].[AsignacionesEstudiantes] VALUES(4,2);
