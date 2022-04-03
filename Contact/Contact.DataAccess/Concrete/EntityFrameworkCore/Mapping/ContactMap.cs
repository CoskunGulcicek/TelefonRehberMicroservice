using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.DataAccess.Concrete.Mapping
{
    public class ContactMap : IEntityTypeConfiguration<Contact.Entities.Concrete.Contact>
    {
        public void Configure(EntityTypeBuilder<Contact.Entities.Concrete.Contact> builder)
        {
              builder.HasMany(x => x.ContactInformations)
                .WithOne(x => x.Contact)
                .HasForeignKey(x => x.ContactUUID);
        }
    }
}
