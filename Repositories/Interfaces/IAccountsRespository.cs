using BartSolutionsProject.API.Data.Models;

namespace BartSolutionsProject.API.Repositories.Interfaces;
public interface IAccountsRespository
{
    Task<Account> DoesAccountExistAsync(string accountName);    
}