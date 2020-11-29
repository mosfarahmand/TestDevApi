using System.Threading.Tasks;

namespace DevTestApi.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        Task<bool> Complete();

        bool HasChanges();
    }
}