using BudgetManagement.Models;

namespace BudgetManagement.Services
{
    public interface ITypeAccountRepository
    {
        Task CreateAccount(TypeAccountModel accountModel);
        Task<bool> ExistsAccount(string name, int userId);
        Task<IEnumerable<TypeAccountModel>> GetTypesAccount(int userId);
        Task UpdateTypesAccount(TypeAccountModel accountModel);
        Task<TypeAccountModel> GetTypeAccount(int id, int userId);
        Task DeleteTypeAccount(int id);
        Task OrderTypeAccount(IEnumerable<TypeAccountModel> typesAccount);  
    }
}
