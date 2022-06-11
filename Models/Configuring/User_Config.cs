using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ws_Agenda.Models.Configuring
{
    public class User_Config : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(prop => prop.User_Id);

            builder.Property(prop => prop.User_Email)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false);

            builder.Property(prop => prop.User_Password)
                .IsRequired()
                .HasMaxLength(30);

        }
    }
}