SELECT * FROM PhoneBook

--DELETE  PhoneBook WHERE Id > 10


--truncate table Entry
--DELETE PhoneBook
DBCC CHECKIDENT ('PhoneBook', RESEED, 0)

DBCC CHECKIDENT ('PhoneBook')


--DROP TABLE PhoneBook
SELECT * FROM PhoneBook
SELECT * FROM Entry