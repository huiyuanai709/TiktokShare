using Identity.Domain.UserAggregate;

namespace Identity.Domain.CompanyAggregate;

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Balance { get; set; }
    public List<User> Users { get; set; }
}