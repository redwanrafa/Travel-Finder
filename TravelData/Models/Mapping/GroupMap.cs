using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class GroupMap : EntityTypeConfiguration<Group>
    {
        public GroupMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupId);

            // Properties
            this.Property(t => t.GroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Area)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Group");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.NoOfMale).HasColumnName("NoOfMale");
            this.Property(t => t.NoofFemale).HasColumnName("NoofFemale");
            this.Property(t => t.AgeMin).HasColumnName("AgeMin");
            this.Property(t => t.AgeMax).HasColumnName("AgeMax");
            this.Property(t => t.Area).HasColumnName("Area");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.TouristId).HasColumnName("TouristId");

            // Relationships
            this.HasRequired(t => t.Tourist)
                .WithMany(t => t.Groups)
                .HasForeignKey(d => d.TouristId);

        }
    }
}
