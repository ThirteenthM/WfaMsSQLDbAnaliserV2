-- код колонки значение по умолчанию
--select COLUMN_DEFAULT, * from INFORMATION_SCHEMA.COLUMNS WHERE COLUMN_DEFAULT is not null

-- команды констрейнов
--CK_SCALING_RATIO_NUM_DENOM_GREATER_ZERO
--select * from INFORMATION_SCHEMA.CHECK_CONSTRAINTS WHERE CONSTRAINT_NAME = 'CK_SCALING_RATIO_NUM_DENOM_GREATER_ZERO'
--select * from INFORMATION_SCHEMA.PARAMETERS --WHERE CONSTRAINT_NAME = 'DF_UNSATISFIED_DEMAND$DATE_MODIFIED'


---------------------------------------------------------------------------------------------------
-- список объектов БД
---------------------------------------------------------------------------------------------------
--SELECT * FROM sys.all_objects
--SELECT DISTINCT type, type_desc FROM sys.all_objects ORDER BY 1
--SELECT name, type, type_desc, OBJECT_ID FROM sys.all_objects WHERE type = 'X'

---------------------------------------------------------------------------------------------------
-- Поиск вхождения.
---------------------------------------------------------------------------------------------------
DECLARE @strSearchedString varchar(2000) = 'B'

SELECT 
	[ObjectName]=tObjType.name, 
	[ObjectType]=tObjType.type, 
	[Occurrence]=LEN(REPLACE(tObjText.definition,@strSearchedString,@strSearchedString+'x'))-LEN(tObjText.definition)
	
	--[ObjectDescription]=tObjType.type_desc, 
	--[ObjectDefinition]=tObjText.definition, 
	
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
		--CHARINDEX ( @strSearchedString ,tObjText.definition ) > 0
	ORDER BY
		tObjType.name



