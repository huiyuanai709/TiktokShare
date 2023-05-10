using Identity.Domain.CompanyAggregate;

namespace Identity.Domain.UserAggregate;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }

    /// <summary>
    /// 昵称
    /// </summary>
    public string NickName { get; set; }

    /// <summary>
    /// 姓名
    /// </summary>
    public string FullName { get; set; }

    public string Password { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public string ContactPhone { get; set; }
}