
namespace ImageTask.MVC.Helper
{
    public static class DocumentSetting
    {
        public static byte[] ConvertImage(IFormFile file)
        {
            var stream = new MemoryStream();
            file.CopyTo(stream);
            var bytes = stream.ToArray();
            return bytes;
        }
        public static string ConvertToImageSource(byte[] image)
        {
            return "data:image/gif;base64," + Convert.ToBase64String(image);
        }
    }
}
