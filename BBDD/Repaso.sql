create database BudgetManagement;


USE BudgetManagement;
create table Transactions (
	Id int not null identity primary key, 
	UserId nvarchar(450) not null,
	TransactionDate datetime, 
	Monto decimal(5,2) not null, 
	TransactioType int not null, 
	Nota nvarchar(1000) null, 
);



insert into Transactions (UserId, TransactionDate, Monto, TransactioType, Nota) 
	Values('Itzel Roman', GETDATE(), 99.99, 2, NULL),
	('Grachel de los Santos', GETDATE(), 99.99, 2, NULL);
--insert into Transactions (UserId, TransactionDate, Monto, TransactioType, Nota) Values 

select * from Transactions as T where T.UserId = 'Josue Reyes'