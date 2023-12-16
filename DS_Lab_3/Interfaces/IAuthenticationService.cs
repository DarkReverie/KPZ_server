namespace DS_Lab_3.Interfaces;

public interface IAuthenticationService
{
    string AuthenticateUser(string username, string password);
}