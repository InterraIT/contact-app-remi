using ContactsManagementApplication.Services;
using Microsoft.AspNetCore.Mvc;
using ContactsManagementApplication.Models;

namespace ContactsManagementApplication.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ContactController : ControllerBase
{
    private readonly IContactService contactService;
    public ContactController(IContactService contactService)
    {
        this.contactService = contactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await this.contactService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await this.contactService.GetByIdAsync(id));
    }

    [HttpGet]
    public async Task<IActionResult> GetCount()
    {
        return Ok(await this.contactService.GetCountAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Insert([FromBody] Contact contact)
    {
        return Ok(await this.contactService.InsertAsync(contact));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Contact contact)
    {
        return Ok(await this.contactService.UpdateAsync(contact.Id, contact));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await this.contactService.DeleteAsync(id));
    }
}
