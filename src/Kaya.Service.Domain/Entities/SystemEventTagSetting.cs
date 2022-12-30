using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

// Fail, Success, Information, Trace
public class SystemEventTagSetting
{
    public string Tag { get; set; }
    
    public string Style { get; set; }
    
    public class Configuration : IEntityTypeConfiguration<SystemEventTagSetting>
    {
        public void Configure(EntityTypeBuilder<SystemEventTagSetting> builder)
        {
            builder.ToTable("systemEventTagSetting");
            builder.HasKey(s => new {s.Tag});
        }
    }
}