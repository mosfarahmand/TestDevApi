using System.Net.Http;
using System.Threading.Tasks;
using DevTestApi.Contracts;

namespace DevTestApi.Implementation
{
    public class PhotoService : IPhotoService
    {
        #region Private member

        private const string Url = "https://cataas.com/";

        #endregion

        #region get photo

        public async Task<Task<byte[]>> GetPhoto(string option = "c")
        {
            using var httpClient = new HttpClient();
            var result = await httpClient.GetAsync(Url + option);
            return result.Content.ReadAsByteArrayAsync();
        }

        #endregion
    }
}