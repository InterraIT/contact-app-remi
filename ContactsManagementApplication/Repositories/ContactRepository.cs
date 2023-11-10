using ContactsManagementApplication.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ContactsManagementApplication.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly string _jsonFilePath;

    public ContactRepository(IConfiguration configuration)
    {
        _jsonFilePath = configuration["DataFilePath"];
    }

    public async Task<int> DeleteAsync(int id)
    {
        var contacts = await ReadDataFromFile();

        var contactToRemove = contacts.Find(c => c.Id == id);

        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            await WriteDataToFile(contacts);
            return 1; 
        }

        return 0; // Indicate failure (contact not found)
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await ReadDataFromFile();
    }

    public async Task<Contact> GetByIdAsync(int id)
    {
        var contacts = await ReadDataFromFile();
        return contacts.Find(c => c.Id == id);
    }

    public async Task<int> GetCountAsync()
    {
        var contacts = await ReadDataFromFile();
        return contacts.Count;
    }

    public async Task<Contact> InsertAsync(Contact contact)
    {
        var contacts = await ReadDataFromFile();

        contact.Id = contacts.Count + 1;

        contacts.Add(contact);

        await WriteDataToFile(contacts);

        return contact;
    }

    public async Task<int> UpdateAsync(int id, Contact contact)
    {
        var contacts = await ReadDataFromFile();

        var existingContact = contacts.Find(c => c.Id == id);

        if (existingContact != null)
        {
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;

            await WriteDataToFile(contacts);

            return 1;
        }

        return 0; // Indicate failure (contact not found)
    }

    private async Task<List<Contact>> ReadDataFromFile()
    {
        if (!File.Exists(_jsonFilePath))
        {
            return new List<Contact>();
        }

        var jsonString = await File.ReadAllTextAsync(_jsonFilePath);
        return JsonSerializer.Deserialize<List<Contact>>(jsonString);
    }

    private async Task WriteDataToFile(List<Contact> contacts)
    {
        var jsonString = JsonSerializer.Serialize(contacts, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        await File.WriteAllTextAsync(_jsonFilePath, jsonString);
    }
}
