namespace Znak.HelperMethods
{
    public static class FileHelper
    {
        public static byte[] ConvertIFormFileToByteArray(this IFormFile file)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
