using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class EventContent
{
    public Guid EventId { get; set; }
    
    public string Content { get; set; }
    
    public class Configuration : IEntityTypeConfiguration<EventContent>
    {
        public void Configure(EntityTypeBuilder<EventContent> builder)
        {
            builder.ToTable("eventContent");
            builder.HasKey(s => s.EventId);
        }
    }
}