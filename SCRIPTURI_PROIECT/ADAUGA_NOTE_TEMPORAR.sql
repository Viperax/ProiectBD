
use Catalog
go
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