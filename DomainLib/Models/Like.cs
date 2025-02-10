public class Like
{
    public int Id { get; set; }
    public int VideoId { get; set; }
    public string UserId { get; set; }

    public Video Video { get; set; }
}