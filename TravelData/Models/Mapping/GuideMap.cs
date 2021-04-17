using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class GuideMap : EntityTypeConfiguration<Guide>
    {
        public GuideMap()
        {
            // Primary Key
            this.HasKey(t => t.GuideId);

            // Properties
            this.Property(t => t.GuideName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GuideNID)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideEmail)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideAddress)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.GuideContact)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideGender)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideLanguages)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.GuideStatus)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideArea)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuideUserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.GuidePassword)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Guide");
            this.Property(t => t.GuideId).HasColumnName("GuideId");
            this.Property(t => t.GuideName).HasColumnName("GuideName");
            this.Property(t => t.GuideNID).HasColumnName("GuideNID");
            this.Property(t => t.GuideEmail).HasColumnName("GuideEmail");
            this.Property(t => t.GuideDOB).HasColumnName("GuideDOB");
            this.Property(t => t.GuideAddress).HasColumnName("GuideAddress");
            this.Property(t => t.GuideContact).HasColumnName("GuideContact");
            this.Property(t => t.GuideGender).HasColumnName("GuideGender");
            this.Property(t => t.GuideLanguages).HasColumnName("GuideLanguages");
            this.Property(t => t.NoOfTour).HasColumnName("NoOfTour");
            this.Property(t => t.GuideStatus).HasColumnName("GuideStatus");
            this.Property(t => t.GuideRating).HasColumnName("GuideRating");
            this.Property(t => t.GuideArea).HasColumnName("GuideArea");
            this.Property(t => t.GuideUserName).HasColumnName("GuideUserName");
            this.Property(t => t.GuidePassword).HasColumnName("GuidePassword");
        }
    }
}
