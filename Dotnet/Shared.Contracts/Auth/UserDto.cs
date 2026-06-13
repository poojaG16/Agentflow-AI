namespace Shared.Contracts.Auth;

public class UserDto
{
    public Guid Id { get; set; }

    public string Email { get; set; } = string.Empty;
}