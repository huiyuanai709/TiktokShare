namespace Identity.Domain.PublicationAggregate;

public class Publication
{
    public int Id { get; set; }
    public int ShareContentId { get; set; }
    public Guid Uuid { get; set; }
    public string Nickname { get; set; }
    public string ShareId { get; set; }
    public int VideoPlaybackCount { get; set; }
    public int CommentCount { get; set; }
}