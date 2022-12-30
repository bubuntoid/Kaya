using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class EventHeader
{
    public Guid EventId { get; set; }
    
    public string Key { get; set; }
    
    public string Value { get; set; }
    
    public class Configuration : IEntityTypeConfiguration<EventHeader>
    {
        public void Configure(EntityTypeBuilder<EventHeader> builder)
        {
            builder.ToTable("eventHeader");
            builder.HasKey(s => new {s.EventId, s.Key});
        }
    }
}