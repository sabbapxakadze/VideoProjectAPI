﻿public class Comment
{
    public int Id { get; set; }
    public int VideoId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Video Video { get; set; }
}