using Contact.DataAccess.Concrete.Mapping;
using Contact.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.DataAccess.Concrete.EntityFrameworkCore
{
    public class ContactContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql(@"User ID=admin; Password=1; Server=localhost; Port=5432;Database=contactdb;Integrated Security=true;Pooling=true");;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 
            //Burada postresql özelinde UUID yi identitiy olarak belirlemek için aşağıdaki kod satırlarını yazdım
            modelBuilder.Entity<Contact.Entities.Concrete.Contact>()
            .HasKey(x => new {x.UUID });
            modelBuilder.Entity<Contact.Entities.Concrete.Contact>()
            .Property(x => x.UUID)
            .ValueGeneratedOnAdd();
            modelBuilder.HasPostgresExtension("uuid-ossp");
            #endregion

            #region
            //fluent api ile modellerimi dataannotation ettim
            modelBuilder.ApplyConfiguration(new ContactMap());
            modelBuilder.ApplyConfiguration(new InformationTypeMap());
            modelBuilder.ApplyConfiguration(new ContactInformationMap());
            #endregion
        }

        public DbSet<Contact.Entities.Concrete.Contact> Contacts { get; set; }
        public DbSet<ContactInformation>  ContactInformations { get; set; }
        public DbSet<InformationType> InformationTypes { get; set; }

    }
}
