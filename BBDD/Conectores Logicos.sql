USE BudgetManagement;

-- Where with In
select * from Transactions
	Where UserId in ('Josue Reyes', 'Isaac Perez')

select * from Transactions
	Where UserId like '%j%' --> busca un registro que contenga j al inicio o fin

select * from Transactions
	Where UserId not like 'j%' --> todos los registros que no terminen con j

------------------------------------------------------------------------------------------------
-- Conectores Logicos.
select * from Transactions
	Where UserId not like '%j%' and Nota is not null --> operador and, puedes poner mas and

select * from Transactions
	Where UserId not like '%j%' or Nota is not null --> operador or

select * from Transactions
	Where (UserId = 'Josue Reyes'and Monto = 777.80) OR UserId = 'abc'

