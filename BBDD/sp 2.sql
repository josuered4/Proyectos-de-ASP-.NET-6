USE [BudgetManagement]
GO
/****** Object:  StoredProcedure [dbo].[Insert_Transactions]    Script Date: 13/04/2023 08:23:10 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[Insert_Transactions]
--Alter -->update
	@UserId nvarchar(450),
	@TransactionDate date,
	@TransactionTypeId int,
	@Monto decimal(18,2),
	@Nota nvarchar(1000) = null -->por que puede ser null
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO Transactions (UserId, TransactionDate, TransactionTypeId, Monto, Nota)
		VALUES(@UserId, @TransactionDate, @TransactionTypeId, @Monto, @Nota);
END
