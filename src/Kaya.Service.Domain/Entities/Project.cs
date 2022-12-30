using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class Project
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    
    public string Name { get; set; }
    
    public string PrivateKey { get; set; }
    
    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new HashSet<Event>();

    public virtual ICollection<ProjectEventTagSetting> TagSettings { get; set; } = new HashSet<ProjectEventTagSetting>();

    public class Configuration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");
            builder.HasKey(s => s.Id);
        }
    }
}