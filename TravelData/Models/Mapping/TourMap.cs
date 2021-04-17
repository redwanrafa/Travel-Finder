using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class TourMap : EntityTypeConfiguration<Tour>
    {
        public TourMap()
        {
            // Primary Key
            this.HasKey(t => t.TourId);

            // Properties
            this.Property(t => t.Area)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tour");
            this.Property(t => t.TourId).HasColumnName("TourId");
            this.Property(t => t.GuideId).HasColumnName("GuideId");
            this.Property(t => t.GroupFormedId).HasColumnName("GroupFormedId");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.MoneyCal).HasColumnName("MoneyCal");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.NoOfDays).HasColumnName("NoOfDays");
            this.Property(t => t.Area).HasColumnName("Area");

            // Relationships
            this.HasOptional(t => t.Group)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.GroupId);
            this.HasOptional(t => t.Group_Formed)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.GroupFormedId);
            this.HasRequired(t => t.Guide)
                .WithMany(t => t.Tours)
                .HasForeignKey(d => d.GuideId);

        }
    }
}
