using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryWebAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext (DbContextOptions<LibraryContext> options) : base(options){ }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>(){
                new User( 1, "Rosa", "Fortaleza", "Rua A", "rosa@gmail.com"),
                new User( 2, "Alice", "Caucaia", "Rua B", "alice@gmail.com"),
                new User( 3, "André", "Fortaleza", "Rua C", "andre@gmail.com"),
                new User( 4, "Nauã", "Fortaleza", "Rua D", "naua@gmail.com"),
            });
            builder.Entity<Book>()
               .HasData(new List<Book>(){
                    new Book(1, "Harry Potter e o Cálice de fogo" ,"Jk Rowling", 1, 23072001, 10, 23),
                    new Book(2, "Estação Carandiru", "Drauzio Varella", 3, 08072001, 68, 90),
                    new Book(3, "O pequeno príncipe", "Antoine de Saint-Exupéry", 4, 23082001, 10, 36),
                    new Book(4, "Percy Jackson e o Ladrão de raios", "Rick Riordan", 2, 23072004, 3, 23),

               });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Saraiva", "São Paulo"),
                    new Publisher(2, "Intríseca", "Rio de Janeiro"),
                    new Publisher(3, "Arqueiro", "Fortaleza"),
                    new Publisher(4, "Bem me quer", "Fortaleza"),
                 
                });

            builder.Entity<Rent>()
                .HasData(new List<Rent>(){
                    new Rent(1, 1, 1,20220923, 280920022, 26092022),
                    new Rent(2, 2, 3,20220923, 280920022, 26092022),
                    new Rent(3, 4, 4,20220923, 280920022, 26092022),
                    new Rent(4, 3, 2,20220923, 280920022, 26092022),
                });
        }

    }
}
