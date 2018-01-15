use Catalog
if exists (select * from sysobjects where id = object_id('dbo.usp_statistica_an1') and sysstat & 0xf = 4)
	drop procedure "dbo"."usp_statistica_an4"
GO

use Catalog
go
CREATE PROCEDURE usp_statistica_an4 @id_dep int , @id_specializare int,  @id_an int
AS
BEGIN
	

	SET NOCOUNT ON;

	--VERIFICAM DACA EXISTA ANUL IN BAZA DE DATE
	DECLARE @EXISTA_ANUL INT;
	SET @EXISTA_ANUL=(SELECT COUNT(AnScolarID) FROM AnScolar WHERE AnScolarID= @id_an )


	DECLARE @REZULTAT TABLE
	(
		NR_STUDENTI INT,
		NR_STUDENTI_INTEGRALISTI INT,
		NR_STUDENTI_R1 INT,
		NR_STUDENTI_R2 INT,
		NR_STUDENTI_R3 INT
	) 

	--DACA EXISTA ANUL ATUNCI
	IF  @EXISTA_ANUL=4 --ANUL EXISTA IN BAZA DE DATE
	BEGIN


	--INSERAM STUDENTII CARE FAC PARTE DIN ACELE GRUPE CARE INDEPLINESC CONDITIILE
	DECLARE @STUDENTI_CURENTI TABLE
	(
		ID INT UNIQUE
	)


	INSERT INTO @STUDENTI_CURENTI
	SELECT StudentiGrupa.StudentID
	FROM StudentiGrupa 
	WHERE  StudentiGrupa.GrupaID
	IN 
	(SELECT GrupaID 
	FROM Grupa 
	WHERE An=4 AND AnScolarID=@id_an AND SpecializareID = @id_specializare ) ------------------


	DECLARE @STUDENTI TABLE
	(
		ID INT UNIQUE,
		RESTANTE INT
	)

	INSERT INTO @STUDENTI
	SELECT StudentID,Restante4 ------------------------
	FROM Student
	WHERE StudentID IN (SELECT ID FROM @STUDENTI_CURENTI)


	DECLARE @NR_STUDENTI INT;
	DECLARE @NR_STUDENTI_INTEGRALISTI INT;
	DECLARE @NR_STUDENTI_R1 INT;
	DECLARE @NR_STUDENTI_R2 INT;
	DECLARE @NR_STUDENTI_R3 INT;


	SET @NR_STUDENTI=(SELECT COUNT(*) FROM @STUDENTI );
	SET @NR_STUDENTI_INTEGRALISTI=(SELECT COUNT(*) FROM @STUDENTI WHERE RESTANTE=0 );
	SET @NR_STUDENTI_R1=(SELECT COUNT(*) FROM @STUDENTI WHERE RESTANTE=1 );
	SET @NR_STUDENTI_R2=(SELECT COUNT(*) FROM @STUDENTI WHERE RESTANTE=2 );
	SET @NR_STUDENTI_R3=(SELECT COUNT(*) FROM @STUDENTI WHERE RESTANTE>=3 );





	INSERT INTO @REZULTAT VALUES (@NR_STUDENTI ,@NR_STUDENTI_INTEGRALISTI ,@NR_STUDENTI_R1 ,@NR_STUDENTI_R2 ,@NR_STUDENTI_R3 );




	END
	
	SELECT * FROM @REZULTAT

END
GO


EXEC usp_statistica_an4 2,1,1