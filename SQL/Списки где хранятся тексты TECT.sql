DBCC FREEPROCCACHE WITH NO_INFOMSGS
DBCC DROPCLEANBUFFERS WITH NO_INFOMSGS
DBCC FREESESSIONCACHE WITH NO_INFOMSGS
GO
---------------------------------------------------------------------------------------------------
-- Поиск вхождения.
---------------------------------------------------------------------------------------------------
DECLARE @strSearchedString varchar(2000) = 'BEGIN'

SELECT tObjType.name, tObjType.type, tObjType.type_desc, tObjText.definition--, LEN(REPLACE(tObjText.definition,@strSearchedString,@strSearchedString+'x'))-LEN(tObjText.definition)
	FROM
		SYS.ALL_OBJECTS tObjType
		INNER JOIN 
		(
			SELECT * FROM SYS.SYSTEM_SQL_MODULES
			UNION ALL
			SELECT * FROM SYS.SQL_MODULES
		)
		tObjText ON tObjText.object_id = tObjType.object_id 
	WHERE
		tObjText.definition like '%'+@strSearchedString+'%'
	ORDER BY
		tObjType.name
GO
DBCC FREEPROCCACHE WITH NO_INFOMSGS
DBCC DROPCLEANBUFFERS WITH NO_INFOMSGS
DBCC FREESESSIONCACHE WITH NO_INFOMSGS
GO
---------------------------------------------------------------------------------------------------
-- Поиск вхождения.
---------------------------------------------------------------------------------------------------
DECLARE @strSearchedString varchar(2000) = 'BEGIN'

SELECT tObjType.name, tObjType.type, tObjType.type_desc, tObjText.definition--, LEN(REPLACE(tObjText.definition,@strSearchedString,@strSearchedString+'x'))-LEN(tObjText.definition)
	FROM
		SYS.ALL_OBJECTS tObjType
		INNER JOIN 
		(
			SELECT * FROM SYS.SYSTEM_SQL_MODULES
			UNION ALL
			SELECT * FROM SYS.SQL_MODULES
		)
		tObjText ON tObjText.object_id = tObjType.object_id 
	WHERE
		CHARINDEX ( @strSearchedString ,tObjText.definition ) > 0
	ORDER BY
		tObjType.name
GO
