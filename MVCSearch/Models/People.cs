namespace MVCSearch.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class People : DbContext
    {
        public People()
            : base("name=PeopleDbContext")
        {
        }

        public virtual DbSet<Person> Peoples { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
