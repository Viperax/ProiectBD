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

	--BEGIN TRY
	--BEGIN TRANSACTION

	
	TRUNCATE TABLE CATALOG_TEMPORAR
	
	INSERT INTO CATALOG_TEMPORAR
	SELECT 
	MaterieID,
	NumeMaterie,
	Profesor1ID,
	Profesor2ID,
	Asistent1ID,
	Asisten2ID,
	ProcentCurs,
	ProcentLaborator,
	ProcentTeme,
	ProcentProiect,
	Examen,
	Credite
	from Materie WHERE GrupaID=@id_grupa AND Sesiune=@semestru;

	TRUNCATE TABLE NOTE_TEMPORAR
	
	INSERT INTO NOTE_TEMPORAR
	SELECT 
	MaterieID,
	NotaCurs,
	NotaLaborator,
	NotaProiect,
	NotaFinala
	from Nota as N1 where StudentID=@id_student AND Sesiune=(select MAX(Sesiune) FROM Nota as N2 WHERE N1.MaterieID=N2.MaterieID) 

	TRUNCATE TABLE CATALOG_CU_NOTE_TEMPORAR
	INSERT INTO  CATALOG_CU_NOTE_TEMPORAR
	SELECT	CATALOG_TEMPORAR.MaterieID,
			CATALOG_TEMPORAR.NumeMaterie,
			CATALOG_TEMPORAR.Profesor1ID,
			CATALOG_TEMPORAR.Profesor2ID,
			CATALOG_TEMPORAR.Asistent1ID,
			CATALOG_TEMPORAR.Asisten2ID,
			CATALOG_TEMPORAR.ProcentCurs,
			CATALOG_TEMPORAR.ProcentLaborator,
			CATALOG_TEMPORAR.ProcentTeme,
			CATALOG_TEMPORAR.ProcentProiect,
			NOTE_TEMPORAR.NotaCurs,
			NOTE_TEMPORAR.NotaLaborator,
			NOTE_TEMPORAR.NotaProiect,
			NOTE_TEMPORAR.NotaFinala,
			CATALOG_TEMPORAR.Examen,
			CATALOG_TEMPORAR.Credite
	FROM CATALOG_TEMPORAR
	INNER JOIN NOTE_TEMPORAR
	ON CATALOG_TEMPORAR.MaterieID = NOTE_TEMPORAR.MaterieID

	SELECT *FROM CATALOG_CU_NOTE_TEMPORAR

	--COMMIT TRANSACTION
	--END TRY
	--BEGIN CATCH
	--ROLLBACK TRANSACTION

	--END CATCH

END
GO



