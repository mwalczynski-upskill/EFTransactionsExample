using System.Data.Entity;
using EFTransactionsExample.Models.EFPaginationExample.Models;

namespace EFTransactionsExample
{
    namespace EFPaginationExample
    {
        public class EfContext : DbContext
        {
            public EfContext() : base("EfTransactionsExampleExample") { }

            public DbSet<Person> Persons { get; set; }
        }
    }
}