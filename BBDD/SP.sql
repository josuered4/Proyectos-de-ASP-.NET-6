-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE Select_TransactionsWithOperationType
--Alter -->update

AS
BEGIN

	SET NOCOUNT ON;

	SELECT T.Id, UserId, Monto, Nota, TypeO.Description
		FROM Transactions as T
	INNER JOIN TypeOperations AS TypeO
		ON TypeO.[Id] = T.TransactionTypeId
	ORDER BY UserId
END
GO
