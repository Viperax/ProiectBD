	IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'CATALOG_CU_NOTE_TEMPORAR'))
	BEGIN
	DROP TABLE CATALOG_CU_NOTE_TEMPORAR
	END

	CREATE TABLE [dbo].[CATALOG_CU_NOTE_TEMPORAR]
	(
		[MaterieID] [int] NOT NULL,
		[NumeMaterie] [nvarchar](100) NOT NULL,
		[Profesor1ID] [int] NOT NULL,
		[Profesor2ID] [int],
		[Asistent1ID] [int] NOT NULL,
		[Asisten2ID] [int],
		[ProcentCurs] [real],
		[ProcentLaborator] [real],
		[ProcentTeme] [real],
		[ProcentProiect] [real],
		[NotaCurs] [int],
		[NotaLaborator] [int],
		[NotaProiect] [int],
		[NotaFinala] [int],
		[Examen] [bit],
		[Credite] [int]
		  
	)