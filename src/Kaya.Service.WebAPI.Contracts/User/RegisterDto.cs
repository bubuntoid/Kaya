namespace Kaya.Service.WebAPI.Contracts.User;

public class RegisterDto
{
    public string Name { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
}