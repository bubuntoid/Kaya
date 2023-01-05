using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class EventTag
{
    public Guid EventId { get; set; }
    
    public string Tag { get; set; }
    
    public class Configuration : IEntityTypeConfiguration<EventTag>
    {
        public void Configure(EntityTypeBuilder<EventTag> builder)
        {
            builder.ToTable("eventTag");
            builder.HasKey(s => new {s.EventId, s.Tag});
        }
    }
}