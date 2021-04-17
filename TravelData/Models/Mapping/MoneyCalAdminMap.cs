using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using TravelEntity;

namespace Travel.Models.Mapping
{
    public class MoneyCalAdminMap : EntityTypeConfiguration<MoneyCalAdmin>
    {
        public MoneyCalAdminMap()
        {
            // Primary Key
            this.HasKey(t => t.MoneyCalAdminId);

            // Properties
            // Table & Column Mappings
            this.ToTable("MoneyCalAdmin");
            this.Property(t => t.MoneyCalAdminId).HasColumnName("MoneyCalAdminId");
            this.Property(t => t.TourId).HasColumnName("TourId");
            this.Property(t => t.Calculation).HasColumnName("Calculation");

            // Relationships
            this.HasRequired(t => t.Tour)
                .WithMany(t => t.MoneyCalAdmins)
                .HasForeignKey(d => d.TourId);

        }
    }
}
