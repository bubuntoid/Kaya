using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kaya.Service.Domain.Entities;

public class Event
{
    public Guid Id { get; set; }
    
    public Guid ProjectId { get; set; }
    
    public string Message { get; set; }
    
    public DateTime Date { get; set; }
    
    public ICollection<string> Tags { get; set; }

    public virtual EventContent Content { get; set; }
    
    public virtual Project Project { get; set; }
    
    public virtual ICollection<EventHeader> Headers { get; set; } = new HashSet<EventHeader>();

    public class Configuration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("event");
            builder.HasKey(s => s.Id);
            
            builder.Property(s => s.Tags)
                .HasConversion(
                    v => string.Join(',', v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}