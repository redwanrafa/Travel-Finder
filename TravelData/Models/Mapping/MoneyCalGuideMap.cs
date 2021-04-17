using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;
namespace Travel.Models.Mapping
{
    public class MoneyCalGuideMap : EntityTypeConfiguration<MoneyCalGuide>
    {
        public MoneyCalGuideMap()
        {
            // Primary Key
            this.HasKey(t => t.MoneyCalGuideId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MoneyCalGuide");
            this.Property(t => t.MoneyCalGuideId).HasColumnName("MoneyCalGuideId");
            this.Property(t => t.TourId).HasColumnName("TourId");
            this.Property(t => t.Calculation).HasColumnName("Calculation");

            // Relationships
            this.HasRequired(t => t.Tour)
                .WithMany(t => t.MoneyCalGuides)
                .HasForeignKey(d => d.TourId);

        }
    }
}
