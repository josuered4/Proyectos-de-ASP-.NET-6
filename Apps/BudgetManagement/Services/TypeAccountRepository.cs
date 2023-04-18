using BudgetManagement.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace BudgetManagement.Services
{
    public class TypeAccountRepository : ITypeAccountRepository
    {
        private readonly string connectionString;
        public TypeAccountRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task CreateAccount(TypeAccountModel accountModel)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>("TypeAccount_Insert", 
                new { UserId = accountModel.UserId, Name = accountModel.Name}, commandType: System.Data.CommandType.StoredProcedure);
            //Agregamos el nombre del procedimiento.
            //Agregamos el await en QuerySingleAsync para que espere a la asignacion del valor 
            accountModel.Id = id;
            
        }


        public async Task<bool> ExistsAccount(string name, int userId)
        {
            using var connection = new SqlConnection(connectionString);
            var exists = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM TypeAccount
                                                                            WHERE Name = @Name AND UserId = @UserId;", 
                                                                            new {name, userId});
            //Esta consulta trae 1 o 0
            return exists == 1;
        }

        public async Task<IEnumerable<TypeAccountModel>> GetTypesAccount(int userId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TypeAccountModel>(@"Select Id, Name, Orden From TypeAccount 
                                                                    Where UserId = @UserId Order By Orden", new { userId });
        }

        public async Task UpdateTypesAccount(TypeAccountModel accountModel)
        {
            using var connection = new SqlConnection(connectionString);
            //ExecuteAsync => para crear o actualizat 
            await connection.ExecuteAsync(@"UPDATE TypeAccount
                                                SET Name = @Name
                                                WHERE Id = @Id", accountModel);
        }

        public async Task<TypeAccountModel> GetTypeAccount(int id, int userId)
        {
            using var connection = new SqlConnection(connectionString);
            return await connection.QueryFirstOrDefaultAsync<TypeAccountModel>(@"
                                            select Id, Name, Orden FROM TypeAccount
	                                            Where Id = @Id and UserId = @UserId", new {id, userId});
        }

        public async Task DeleteTypeAccount(int id)
        {
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync("DELETE TypeAccount Where Id = @Id", new { id });
        }

        public async Task OrderTypeAccount(IEnumerable<TypeAccountModel> typesAccount)
        {
            var query = "Update TypeAccount Set Orden = @Orden Where Id = @Id;";
            using var connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(query, typesAccount);
            //Se ejecutara el query por cada item del elemento
        }
    }
}
