using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class TouristMap : EntityTypeConfiguration<Tourist>
    {
        public TouristMap()
        {
            // Primary Key
            this.HasKey(t => t.TouristId);

            // Properties
            this.Property(t => t.TouristName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TouristEmail)
                .IsRequired()
                .HasMaxLength(80);

            this.Property(t => t.TouristContactNo)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TouristGender)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TouristAddress)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.TouristUserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.TouristPassword)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tourist");
            this.Property(t => t.TouristId).HasColumnName("TouristId");
            this.Property(t => t.TouristName).HasColumnName("TouristName");
            this.Property(t => t.TouristEmail).HasColumnName("TouristEmail");
            this.Property(t => t.TouristContactNo).HasColumnName("TouristContactNo");
            this.Property(t => t.TouristGender).HasColumnName("TouristGender");
            this.Property(t => t.TouristDOB).HasColumnName("TouristDOB");
            this.Property(t => t.TouristAddress).HasColumnName("TouristAddress");
            this.Property(t => t.TouristUserName).HasColumnName("TouristUserName");
            this.Property(t => t.TouristPassword).HasColumnName("TouristPassword");
        }
    }
}
