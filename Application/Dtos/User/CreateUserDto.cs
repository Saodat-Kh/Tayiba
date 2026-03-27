using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.User;

public class CreateUserDto
{
    public string FullName { get; set; }
   [Phone]
    public string PhoneNumber {  get; set; }
}