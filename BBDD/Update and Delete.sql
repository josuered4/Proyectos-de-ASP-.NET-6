USE BudgetManagement;

-- Update --
update Transactions
	set Nota = 'Nota Actualizada' -->actualizacion de un capo especifico 
	Where Id = 1

update Transactions
	set Nota = 'Nota Actualizada', Monto = 777.80 -->varios campos
	Where Id = 1


---Delete---
Delete Transactions
	Where Id = 5 or Id = 6


-- Where with In
select * from Transactions
	Where UserId in ('Josue Reyes', 'Isaac Perez')