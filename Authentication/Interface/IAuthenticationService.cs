namespace IdentityGamaFramework.Authentication.Interface
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated(string token);
    }
}
