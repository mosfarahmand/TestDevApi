using System.Threading.Tasks;

namespace DevTestApi.Contracts
{
    public interface IPhotoService
    {
        Task<Task<byte[]>> GetPhoto(string option = "c");
    }
}