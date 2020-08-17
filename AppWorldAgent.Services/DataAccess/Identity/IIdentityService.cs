using AppWorldAgent.Services.Criteria;
using AppWorldAgent.Services.Entity;
using System.Threading.Tasks;

namespace AppWorldAgent.Services.DataAccess.Identity
{
    public interface IIdentityService
    {
        Task<UserProfileModel> SignInAsync(UserCredentialCriteria model);
    }
}