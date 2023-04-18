USE BudgetManagement;

-- GRUPOS Y OPERACIONES ---

--Suma de todos los registros --
SELECT sum(Monto) as Suma 
FROM Transactions

-- Suma los montos y los agrupa por usuario
	--La agrupacion de ara segun la columnas que se especifiqen en el group
SELECT sum(Monto) as Suma, UserId
	FROM Transactions
	GROUP BY UserId


SELECT sum(Monto) as Suma, UserId
	FROM Transactions
	where TransactioType = 1
	GROUP BY UserId


SELECT sum(Monto) as Suma, UserId, TransactioType
	FROM Transactions
	GROUP BY UserId, TransactioType

------------------------------------CONTEO---------------------------------------------------

SELECT COUNT(Id)
	from Transactions

--- o---

SELECT COUNT(*)
	FROM Transactions
		WHERE NOTA IS NOT NULL


-- Conteo con grupos ---

SELECT COUNT(*)
	FROM Transactions
	WHERE UserId = 'Josue Reyes'
	GROUP BY UserId


------------------------------------PROMEDIO---------------------------------------------------

select count(*) AS Conteo, UserId, AVG(Monto) as Promedio
from Transactions
group by UserId