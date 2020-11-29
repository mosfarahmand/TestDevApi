using System.Threading.Tasks;
using DevTestApi.Contracts;
using DevTestApi.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevTestApi.Controllers
{
    /// <summary>
    /// Photo API 
    /// </summary>
    [Authorize]
    public class PhotoController : BaseApiController
    {
        #region Private members

        private readonly IPhotoService _photoService;

        #endregion

        #region Constructor

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        #endregion

        #region Random flip image

        /// <summary>
        /// Rotate photo 180 degree
        /// </summary>
        /// <returns>Flip image</returns>
        [HttpGet("random-cat-flip-photo")]
        public async Task<FileContentResult> GetPhotoFlip()
        {
            var result = await _photoService.GetPhoto().Result;
            var imgResult = ImageHelper.RotateImage(result);
            return File(imgResult, "image/jpeg");
        }

        #endregion

        #region Random image

        /// <summary>
        /// Random cat image
        /// </summary>
        /// <returns>Random image</returns>
        [HttpGet("random-cat-photo")]
        public async Task<FileContentResult> GetPhoto()
        {
            var result = await _photoService.GetPhoto().Result;
            return File(result, "image/jpeg");
        }

        #endregion

        #region Random image with tag

        /// <summary>
        /// Return a random cat with a :tag
        /// </summary>
        /// <param name="tag">Example: cute</param>
        /// <returns>Random image with tag</returns>
        [HttpGet("random-cat-tag/{tag}")]
        public async Task<FileContentResult> GetRandomPhotoWithTag(string tag)
        {
            var option = "c/" + tag;
            var photo = await _photoService.GetPhoto(option).Result;
            return File(photo, "image/jpeg");
        }

        #endregion

        #region Random image with text

        /// <summary>
        /// Return image after add text
        /// </summary>
        /// <param name="text">Example: Hello</param>
        /// <returns>Random image after add text</returns>
        [HttpGet("random-cat-text/{text}")]
        public async Task<FileContentResult> GetRandomPhotoWithText(string text)
        {
            var option = "c/s/" + text;
            var photo = await _photoService.GetPhoto(option).Result;
            return File(photo, "image/jpeg");
        }

        #endregion

        #region Random gif

        /// <summary>
        /// Return random gif
        /// </summary>
        /// <returns>Return random gif</returns>
        [HttpGet("random-cat-gif")]
        public async Task<FileContentResult> GetRandomGif()
        {
            var option = "c/gif";
            var photo = await _photoService.GetPhoto(option).Result;
            return File(photo, "image/jpeg");
        }

        #endregion
    }
}