using System.ComponentModel.DataAnnotations;

namespace ContactsManagementApplication.Models;

public class Contact
{
    [Required]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string Email { get; set; }

}
