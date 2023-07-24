namespace IdentityGama.Interface.Authorization
{
    public interface IAuthorizationService
    {
        bool IsAuthorized(string token, string role);
    }
}