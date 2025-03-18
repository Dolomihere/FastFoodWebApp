using Assignment_NET104.Services.Interfaces;

namespace Assignment_NET104.Services
{
    public class Imagesvc : IFileImage
    {
        protected string _webRootPath;
        public Imagesvc(IWebHostEnvironment environment)
        {
            _webRootPath = environment.WebRootPath;
        }

        public void RemoveImage(string imageName)
        {
            string filePath = Path.Combine(_webRootPath, "images", imageName);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public void SaveImage(IFormFile file, string path)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("Không gửi được file");
            }

            string filePath = Path.Combine(_webRootPath, path, file.FileName);

            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory); 
            }

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
    }
}
