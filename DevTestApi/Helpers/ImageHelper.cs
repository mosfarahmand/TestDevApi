using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace DevTestApi.Helpers
{
    public static class ImageHelper
    {
        #region Rotate image

        public static byte[] RotateImage(byte[] imageInBytes)
        {
            using var image = Image.Load(imageInBytes);
            RotateMode rotateMode;
            const FlipMode flipMode = FlipMode.Horizontal;
            image.Mutate(x => x.RotateFlip(RotateMode.Rotate180, flipMode));
            var imageFormat = Image.DetectFormat(imageInBytes);
            return ImageToByteArray(image, imageFormat);
        }

        #endregion

        #region Image to byte array

        private static byte[] ImageToByteArray(Image<Rgba32> image, IImageFormat imageFormat)
        {
            using var ms = new MemoryStream();
            image.Save(ms, imageFormat);
            return ms.ToArray();
        }

        #endregion
    }
}