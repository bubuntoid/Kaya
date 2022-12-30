using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class ProjectEventTagSetting
{
    public Guid ProjectId { get; set; }
    
    public string Tag { get; set; }
    
    public string Style { get; set; }
    
    public class Configuration : IEntityTypeConfiguration<ProjectEventTagSetting>
    {
        public void Configure(EntityTypeBuilder<ProjectEventTagSetting> builder)
        {
            builder.ToTable("projectEventTagSetting");
            builder.HasKey(s => new {s.ProjectId, s.Tag});
        }
    }
}