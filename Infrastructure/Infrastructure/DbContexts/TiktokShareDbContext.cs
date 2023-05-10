using Identity.Domain.AttachmentAggregate;
using Identity.Domain.CompanyAggregate;
using Identity.Domain.ExpenseAggregate;
using Identity.Domain.PublicationAggregate;
using Identity.Domain.RechargeAggregate;
using Identity.Domain.ShareContentAggregate;
using Identity.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts;

public class TiktokShareDbContext : DbContext
{
    /// <summary>
    /// 公司
    /// </summary>
    public DbSet<Company> Companies { get; set; }

    /// <summary>
    /// 用户
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// 充值
    /// </summary>
    public DbSet<Recharge> Recharges { get; set; }

    /// <summary>
    /// 分享内容
    /// </summary>
    public DbSet<ShareContent> ShareContents { get; set; }
    
    /// <summary>
    /// 发布
    /// </summary>
    public DbSet<Publication> Publications { get; set; }

    /// <summary>
    /// 消费
    /// </summary>
    public DbSet<Expense> Expenses { get; set; }

    /// <summary>
    /// 附件
    /// </summary>
    public DbSet<Attachment> Attachments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.Company)
            .WithMany(c => c.Users);

        modelBuilder.Entity<Attachment>()
            .HasOne(a => a.ShareContent)
            .WithMany(sc => sc.Attachments);
    }
}