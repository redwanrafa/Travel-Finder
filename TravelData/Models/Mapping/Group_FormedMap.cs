using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class Group_FormedMap : EntityTypeConfiguration<Group_Formed>
    {
        public Group_FormedMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupFormedId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Group_Formed");
            this.Property(t => t.GroupFormedId).HasColumnName("GroupFormedId");
            this.Property(t => t.GroupReqId).HasColumnName("GroupReqId");
            this.Property(t => t.TouristIdEx).HasColumnName("TouristIdEx");

            // Relationships
            this.HasRequired(t => t.Group_Request)
                .WithMany(t => t.Group_Formed)
                .HasForeignKey(d => d.GroupReqId);

        }
    }
}
