using ContactsManagementApplication.Models;
using System.Diagnostics.Metrics;

namespace ContactsManagementApplication.Services;

public interface IContactService
{
    Task<int> DeleteAsync(int id);
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact> GetByIdAsync(int id);
    Task<int> GetCountAsync();
    Task<Contact> InsertAsync(Contact contact);
    Task<int> UpdateAsync(int id, Contact contact);
}
