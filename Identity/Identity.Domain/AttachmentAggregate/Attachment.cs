using Identity.Domain.ShareContentAggregate;

namespace Identity.Domain.AttachmentAggregate;

public class Attachment
{
    public int Id { get; set; }
    public ShareContent ShareContent { get; set; }
    public string AttachmentUrl { get; set; }
    public int Type { get; set; }
}