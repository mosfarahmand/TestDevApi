using System.Threading.Tasks;
using DevTestApi.DAL.Models;

namespace DevTestApi.Contracts
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}