using LibraryWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace LibraryWebAPI.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(new List<User>(){
                new User( 1, "Rosalice Nogueira", "Fortaleza", "Rua A", "rosa@gmail.com"),
                new User( 2, "Ana Pontes", "Caucaia", "Rua B", "ana@gmail.com"),
                new User( 3, "André Vieira", "Fortaleza", "Rua C", "andre@gmail.com"),
                new User( 4, "Marcos Aurélio", "São Paulo", "Rua Gorvenador Sampaio", "marcos@gmail.com"),
                new User( 5, "Antonia Villela", "Rio de Janeiro", "Rua D", "antonia@gmail.com"),
                new User( 6, "Juarez Fernandez", "Aquiraz", "Rua Avelino Marçal", "juarez@gmail.com"),

            });
            builder.Entity<Book>()
               .HasData(new List<Book>(){
                    new Book(1, "Harry Potter e o Cálice de fogo" ,"Jk Rowling", 1, DateTime.Parse("10/11/2000"), 10, 1, 2),
                    new Book(2, "Estação Carandiru", "Drauzio Varella", 3,  DateTime.Parse("07/06/1999"), 68, 2, 4),
                    new Book(3, "O pequeno príncipe", "Antoine de Saint-Exupéry", 4,  DateTime.Parse("10/04/1943"), 10, 1, 3),
                    new Book(4, "Code Clean", " Robert Cecil Martin", 4,  DateTime.Parse("01/08/2008"), 10, 1, 3),
                    new Book(5, "E o vento levou", "Margareth Mitchell", 4,  DateTime.Parse("10/04/1999"), 10, 1, 3),


               });

            builder.Entity<Publisher>()
                .HasData(new List<Publisher>(){
                    new Publisher(1, "Saraiva", "São Paulo"),
                    new Publisher(2, "Intríseca", "Rio de Janeiro"),
                    new Publisher(3, "Arqueiro", "Fortaleza"),
                    new Publisher(4, "Bem me quer", "Fortaleza"),

                });

            builder.Entity<Rent>()
                .HasData(new List<Rent>()
                {
                    new Rent(1, 1, 1, DateTime.Parse("22/08/2022"), DateTime.Parse("23/08/2022"),  DateTime.Parse("22/08/2022")),
                    new Rent(2, 2, 3, DateTime.Parse("22/08/2022"), DateTime.Parse("25/08/2022"),  DateTime.Parse("25/08/2022")),
                    new Rent(3, 3, 2, DateTime.Parse("01/09/2022"), DateTime.Parse("04/08/2022"),  DateTime.Parse("10/09/2022")),
                    new Rent(4, 6, 4, DateTime.Parse("05/09/2022"), DateTime.Parse("15/10/2022"),  DateTime.Parse("25/10/2022")),
                    
                });
        }
      
    }
}
