use Catalog
if exists (select * from sysobjects where id = object_id('dbo.usp_catalog_sesiunea_x') and sysstat & 0xf = 4)
	drop procedure "dbo"."usp_catalog_sesiunea_x"
GO

use Catalog
go
CREATE PROCEDURE usp_catalog_sesiunea_x @id_student int , @id_grupa int, @semestru int
AS
BEGIN
	
	SET NOCOUNT ON;
	
	IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'CATALOG_TEMPORAR'))
	BEGIN
	DROP TABLE CATALOG_TEMPORAR
	END

	CREATE TABLE [dbo].[CATALOG_TEMPORAR]
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
		[Examen] [bit],
		[Credite] [int],
		[NotaCurs] [int],
		[NotaLaborator] [int],
		[NotaProiect] [int],
		[NotaFinala] [int],
		[Admis] [bit]  
	)
	
	INSERT INTO CATALOG_TEMPORAR (MaterieID,NumeMaterie,Profesor1ID,Profesor2ID,Asistent1ID,ProcentCurs,ProcentLaborator,ProcentTeme,ProcentProiect,Examen,Credite)
	SELECT MaterieID,NumeMaterie,Profesor1ID,Profesor2ID,Asistent1ID,ProcentCurs,ProcentLaborator,ProcentTeme,ProcentProiect,Examen,Credite
	from Materie WHERE GrupaID=@id_grupa AND Sesiune=@semestru;

	IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND  TABLE_NAME = 'NOTE_TEMPORAR'))
	BEGIN
	DROP TABLE NOTE_TEMPORAR
	END

	CREATE TABLE [dbo].[NOTE_TEMPORAR]
	(
		[MaterieID] [int] NOT NULL UNIQUE,
		[NotaCurs] [int] ,
		[NotaLaborator] [int] ,
		[NotaProiect] [int] ,
		[NotaFinala] [int],
	)

	INSERT INTO NOTE_TEMPORAR (MaterieID,NotaCurs,NotaLaborator,NotaProiect,NotaFinala)
	SELECT MaterieID,NotaCurs,NotaLaborator,NotaProiect,NotaFinala
	from Nota as N1 where StudentID=@id_student AND Sesiune= (select MAX(Sesiune) FROM Nota as N2 WHERE N1.MaterieID=N2.MaterieID) 
	
	SELECT	CATALOG_TEMPORAR.MaterieID AS "MaterieID" ,
			CATALOG_TEMPORAR.NumeMaterie AS "NumeMaterie",
			CATALOG_TEMPORAR.Profesor1ID AS "Profesor1ID",
			CATALOG_TEMPORAR.Profesor2ID AS "Profesor2ID",
			CATALOG_TEMPORAR.Asistent1ID AS "Asistent1ID",
			CATALOG_TEMPORAR.Asisten2ID AS "Asisten2ID",
			CATALOG_TEMPORAR.ProcentCurs AS "ProcentCurs",
			CATALOG_TEMPORAR.ProcentLaborator AS "ProcentLaborator",
			CATALOG_TEMPORAR.ProcentTeme AS "ProcentTeme",
			CATALOG_TEMPORAR.ProcentProiect AS "ProcentProiect",
			NOTE_TEMPORAR.NotaCurs AS "NotaCurs",
			NOTE_TEMPORAR.NotaLaborator AS "NotaLaborator",
			NOTE_TEMPORAR.NotaProiect AS "NotaProiect",
			NOTE_TEMPORAR.NotaFinala AS "NotaFinala",
			CATALOG_TEMPORAR.Examen AS "Examen",
			CATALOG_TEMPORAR.Credite AS "Credite"
	FROM CATALOG_TEMPORAR
	INNER JOIN NOTE_TEMPORAR
	ON CATALOG_TEMPORAR.MaterieID = NOTE_TEMPORAR.MaterieID

END
GO

exec usp_catalog_sesiunea_x 1, 1, 1
