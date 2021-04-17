using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class Group_RequestMap : EntityTypeConfiguration<Group_Request>
    {
        public Group_RequestMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupReqId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Group_Request");
            this.Property(t => t.GroupReqId).HasColumnName("GroupReqId");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.TouristIdEx).HasColumnName("TouristIdEx");

            // Relationships
            this.HasRequired(t => t.Group)
                .WithMany(t => t.Group_Request)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
