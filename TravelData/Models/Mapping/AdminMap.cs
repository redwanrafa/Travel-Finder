using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class AdminMap : EntityTypeConfiguration<Admin>
    {
        public AdminMap()
        {
            // Primary Key
            this.HasKey(t => t.AdminId);

            // Properties
            this.Property(t => t.AdminName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AdminEmail)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.AdminUserName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AdminPassword)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Admin");
            this.Property(t => t.AdminId).HasColumnName("AdminId");
            this.Property(t => t.AdminName).HasColumnName("AdminName");
            this.Property(t => t.AdminEmail).HasColumnName("AdminEmail");
            this.Property(t => t.AdminUserName).HasColumnName("AdminUserName");
            this.Property(t => t.AdminPassword).HasColumnName("AdminPassword");
        }
    }
}
