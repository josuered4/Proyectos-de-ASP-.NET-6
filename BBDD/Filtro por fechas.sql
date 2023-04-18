USE BudgetManagement;

-- Filtros con Fechas --


select * from Transactions -->fecha por igualdad
	where TransactionDate = '2023-04-11 21:32:08.803'
	
select * from Transactions 
	where TransactionDate >= '2023-04-11 21:32:08.803'and TransactionDate <= '2023-04-11 21:32:08.803'



-- Filtros por Año

select * from Transactions 
	where YEAR(TransactionDate) = 2021

select * from Transactions 
	where MONTH(TransactionDate) = 10

select * from Transactions 
	where DAY(TransactionDate) = 3
