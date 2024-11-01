using BartSolutionsProject.API.Data;
using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BartSolutionsProject.API.Repositories;
public class ContactsRepository : IContactsRepository
{
    private readonly DataContext _context;

    public ContactsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        _context.Contacts.Add(contact);
        await _context.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> DoesContactExistAsync(string email)
    {
        return await _context.Contacts.FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<Contact> UpdateContactAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync();
        return contact;
    }
}