using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class AreaMap : EntityTypeConfiguration<Area>
    {
        public AreaMap()
        {
            // Primary Key
            this.HasKey(t => t.AreaId);

            // Properties
            this.Property(t => t.AreaName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Area");
            this.Property(t => t.AreaId).HasColumnName("AreaId");
            this.Property(t => t.AreaName).HasColumnName("AreaName");
            this.Property(t => t.MoneyCal).HasColumnName("MoneyCal");
        }
    }
}
