using ContactsManagementApplication.Models;

namespace ContactsManagementApplication.Repositories;

public interface IContactRepository
{
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task<int> GetCountAsync();
    Task<Contact> InsertAsync(Contact contact);
    Task<int> UpdateAsync(int id, Contact contact);
}
