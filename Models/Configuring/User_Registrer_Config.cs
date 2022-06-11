using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ws_Agenda.Models.Configuring
{
    public class User_Registrer_Config : IEntityTypeConfiguration<User_Registrer>
    {
        public void Configure(EntityTypeBuilder<User_Registrer> builder)
        {
 

            builder.Property(p => p.User_Name)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.User_LastName)
                .IsRequired()
                .HasMaxLength(256);

            builder.Property(p => p.User_photo)
                .IsUnicode(false)
                .HasColumnType("varbinary");

            builder.Property(p => p.User_Phone)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.User_BirthDate)
                .IsRequired();

           
                
        }
    }
}
