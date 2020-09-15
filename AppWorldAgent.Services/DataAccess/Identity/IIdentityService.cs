using AppWorldAgent.Infrastructure.Models.User;
using AppWorldAgent.Services.Criteria;
using AppWorldAgent.Services.Entity;
using System.Threading.Tasks;

namespace AppWorldAgent.Services.DataAccess.Identity
{
    public interface IIdentityService
    {
        Task<UserToken> SignInAsync(UserCredentialCriteria model);
        Task<UserProfileModel> RegisterAsync(RegisterUserCriteria model);
    }
}