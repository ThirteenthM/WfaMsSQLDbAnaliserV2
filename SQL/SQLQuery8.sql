
GO
-- Returns a DIFFERENCE value of 4, the least possible difference.
SELECT SOUNDEX('Green'), SOUNDEX('Greene'), DIFFERENCE('Green','Greene');
GO
-- Returns a DIFFERENCE value of 0, the highest possible difference.
SELECT SOUNDEX('Blotchet-Halls'), SOUNDEX('Greene'), DIFFERENCE('Blotchet-Halls', 'Greene');
GO


SELECT SOUNDEX('Дмитренко'), SOUNDEX('Дмитриенко'), DIFFERENCE('Green','Greene');
SELECT SOUNDEX('Иванов'), SOUNDEX('Иванова'), DIFFERENCE('Green','Greene');
