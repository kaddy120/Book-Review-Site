using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Database
{
    public class AppDbContext: IdentityDbContext<User>
    {
        private readonly BooksSeeding booksSeeding;

        public AppDbContext(DbContextOptions<AppDbContext> options, BooksSeeding booksSeeding)
            : base(options){
            this.booksSeeding = booksSeeding;
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Books>().Property(b => b.Category).HasConversion(C => string.Join(',', C),
            //    C => C.Split(',', StringSplitOptions.RemoveEmptyEntries));

            //Debugger.Launch();
            var Books_ = this.booksSeeding.ReadFromFile().GetAwaiter().GetResult().ToArray();
            
            modelBuilder.Entity<Book>().HasData(Books_);
            base.OnModelCreating(modelBuilder);

        }

    }
}
