using Identity.Domain.AttachmentAggregate;

namespace Identity.Domain.ShareContentAggregate;

public class ShareContent
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Topic { get; set; }
    public string Content { get; set; }
    public DateTime CreateTime { get; set; }
    public List<Attachment> Attachments { get; set; }
}