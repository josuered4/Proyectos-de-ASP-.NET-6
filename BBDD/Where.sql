USE BudgetManagement;

select * from Transactions as T Order by id --> Asendente
select * from Transactions as T Order by Id desc -->Desendente
select * from Transactions as T Order by TransactioType, UserId --> Dos columnas


select Id, UserId
	from Transactions 
	where Id = 1

select Id, UserId
	from Transactions 
	where Id <> 1

select Id, UserId, Nota
	from Transactions 
	where Nota is not null