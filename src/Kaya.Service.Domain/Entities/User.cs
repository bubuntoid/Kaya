using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    
    public string Login { get; set; }
    
    public string Password { get; set; }
    
    public string PrivateKey { get; set; }
    
    public virtual ICollection<Project> Projects { get; set; } = new HashSet<Project>();
    
    public class Configuration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(s => s.Id);
        }
    }
}