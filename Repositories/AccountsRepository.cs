using BartSolutionsProject.API.Data;
using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BartSolutionsProject.API.Repositories;
public class AccountsRepository : IAccountsRespository
{
    private readonly DataContext _context;

    public AccountsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Account> DoesAccountExistAsync(string accountName)
    {
        return await _context.Accounts.FirstOrDefaultAsync(x => x.Name == accountName);
    }
}