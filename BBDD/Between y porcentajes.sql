USE BudgetManagement;

-- Rangos con BETWEEN --
	
select * from Transactions 
	where YEAR(TransactionDate) BETWEEN '2021' AND '2022'

select * from Transactions 
	where Monto BETWEEN 350 AND 500

select * from Transactions 
	where Monto NOT BETWEEN 350 AND 500 --> NEGACION


-- Top --
select TOP 2 * from Transactions --> Top NumeroDeRegistros a traer
	where TransactioType = 1
	--Si agregamos el where traera los primero registros con 
	--cumplan la condicion, sin el where trare los primero de la tabla


select TOP 50 PERCENT * from Transactions --> Trae el 50% de los registros
	--Con Where treara el 50% de los resultados que cumpla la condicion