using Microsoft.AspNetCore.Http;

public class VideoUploadDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public IFormFile VideoFile { get; set; } 
}