using ContactsManagementApplication.Models;
using ContactsManagementApplication.Repositories;

namespace ContactsManagementApplication.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository contactRepository;
    public ContactService(IContactRepository contactRepository)
    {
        this.contactRepository = contactRepository;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await contactRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await contactRepository.GetAllAsync();
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        return await contactRepository.GetByIdAsync(id);
    }

    public async Task<int> GetCountAsync()
    {
        return await contactRepository.GetCountAsync();
    }

    public async Task<Contact> InsertAsync(Contact contact)
    {
        return await contactRepository.InsertAsync(contact);
    }

    public async Task<int> UpdateAsync(int id, Contact contact)
    {
        return await contactRepository.UpdateAsync(id, contact);
    }
}
