using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            // Primary Key
            this.HasKey(t => t.RatingId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Rating");
            this.Property(t => t.RatingId).HasColumnName("RatingId");
            this.Property(t => t.GuideId).HasColumnName("GuideId");
            this.Property(t => t.NoOfTour).HasColumnName("NoOfTour");
            this.Property(t => t.Bonus).HasColumnName("Bonus");

            // Relationships
            this.HasRequired(t => t.Guide)
                .WithMany(t => t.Ratings)
                .HasForeignKey(d => d.GuideId);

        }
    }
}
