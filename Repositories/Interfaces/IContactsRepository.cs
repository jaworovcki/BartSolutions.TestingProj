using BartSolutionsProject.API.Data.Models;

namespace BartSolutionsProject.API.Repositories.Interfaces;
public interface IContactsRepository
{
    Task<Contact> DoesContactExistAsync(string email);
    Task<Contact> CreateContactAsync(Contact contact);
    Task<Contact> UpdateContactAsync(Contact contact);
}