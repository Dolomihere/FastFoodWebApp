namespace Assignment_NET104.Services.Interfaces
{
    public interface IFileImage
    {
        void RemoveImage(string imageName);
        void SaveImage(IFormFile file, string path);
    }
}
