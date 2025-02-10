public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string FilePath { get; set; } // Path to the uploaded video file
    public DateTime UploadedAt { get; set; }

    // List of Comments (One-to-Many)
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Like> Likes { get; set; } = new List<Like>();

    // Like Count (Optional: Can be computed)
    public int LikeCount { get; set; } = 0;
}