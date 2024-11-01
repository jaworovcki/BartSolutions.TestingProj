using BartSolutionsProject.API.Data.Models;
using BartSolutionsProject.API.DTOs;
using BartSolutionsProject.API.Repositories.Interfaces;
using BartSolutionsProject.API.Services.Interfaces;

namespace BartSolutionsProject.API.Services;
public class IncidentService : IIncidentService
{
    private readonly IAccountsRespository _accountsRepository;
    private readonly IContactsRepository _contactsRepository;
    private readonly IIncidentsRepository _incidentsRepository;

    public IncidentService(IAccountsRespository accountsRespository,
        IContactsRepository contactsRepository,
        IIncidentsRepository incidentsRepository)
    {
        _accountsRepository = accountsRespository;
        _contactsRepository = contactsRepository;
        _incidentsRepository = incidentsRepository;

    }

    /// <summary>
    /// Creates a new incident based on the provided data transfer object (DTO).
    /// This method ensures that the account exists, retrieves or creates the contact,
    /// and then creates the incident linked to the account and contact.
    /// </summary>
    /// <param name="createIncidentDto"></param>
    /// <returns></returns>

    public async Task<Incident> CreateIncidentAsync(CreateIncidentDto createIncidentDto)
    {
        try
        {
            var account = await GetAccountAsync(createIncidentDto.AccountName);
            var contact = await GetOrCreateContactAsync(createIncidentDto, account);

            var incident = await CreateIncidentAsync(createIncidentDto, account);

            return incident;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private async Task<Account> GetAccountAsync(string accountName)
    {
        var account = await _accountsRepository.DoesAccountExistAsync(accountName);

        if (account is null)
        {
            throw new Exception("Account does not exist");
        }

        return account;
    }

    private async Task<Contact> GetOrCreateContactAsync(CreateIncidentDto createIncidentDto, Account account)
    {
        var contact = await _contactsRepository.DoesContactExistAsync(createIncidentDto.ContactEmail);

        if (contact is null)
        {
            contact = await CreateContactAsync(createIncidentDto, account);
        }
        else
        {
            contact = await UpdateContactAsync(contact, createIncidentDto, account);
        }

        return contact;
    }

    private async Task<Contact> CreateContactAsync(CreateIncidentDto createIncidentDto, Account account)
    {
        var contactToCreate = new Contact
        {
            Email = createIncidentDto.ContactEmail,
            FirstName = createIncidentDto.ContactFirstName,
            LastName = createIncidentDto.ContactLastName,
            Account = account
        };

        return await _contactsRepository.CreateContactAsync(contactToCreate);
    }

    private async Task<Contact> UpdateContactAsync(Contact contact, CreateIncidentDto createIncidentDto, Account account)
    {
        contact.FirstName = createIncidentDto.ContactFirstName;
        contact.LastName = createIncidentDto.ContactLastName;

        if (contact.Account.Id != account.Id)
        {
            contact.Account = account;
        }

        return await _contactsRepository.UpdateContactAsync(contact);
    }

    private async Task<Incident> CreateIncidentAsync(CreateIncidentDto createIncidentDto, Account account)
    {
        var incident = new Incident
        {
            Description = createIncidentDto.IncidentDescription
        };

        incident.Accounts.Add(account);

        await _incidentsRepository.CreateIncidentAsync(incident);

        return incident;
    }

    public async Task<Incident> GetIncidentByNameAsync(string incidentName)
    {
        var incident =  await _incidentsRepository.GetIncidentByNameAsync(incidentName);

        if (incident is null)
        {
            throw new Exception("Incident does not exist");
        }

        return incident;
    }
}