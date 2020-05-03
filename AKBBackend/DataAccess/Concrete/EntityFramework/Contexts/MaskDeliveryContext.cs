using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class MaskDeliveryContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MaskeTakip;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<PersonWhoHasNotTcNumber> PersonWhoHasNotTcNumber { get; set; }
        public DbSet<PersonWhoHasTcNumber> PersonWhoHasTcNumber { get; set; }

        public DbSet<MaskDelivery> MaskDelivery { get; set; }
    }
}
