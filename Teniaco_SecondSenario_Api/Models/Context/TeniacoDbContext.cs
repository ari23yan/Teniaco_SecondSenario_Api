using Microsoft.EntityFrameworkCore;
using Teniaco_SecondSenario_Api.Models.Entities.Person;

namespace Teniaco_SecondSenario_Api.Models.Context
{
    public class TeniacoDbContext:DbContext
    {
        public TeniacoDbContext(DbContextOptions<TeniacoDbContext> options) : base(options) { }
        public DbSet<Person> Persons { get; set; }

    }
}
