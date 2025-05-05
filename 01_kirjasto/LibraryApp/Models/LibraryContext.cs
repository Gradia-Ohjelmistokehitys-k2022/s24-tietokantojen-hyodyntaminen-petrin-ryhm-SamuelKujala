using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Models
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Määritellään tietokannan yhteysstring ja tarjoaja (esim. SQL Server)
            options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");  // Käytä oikeaa yhteysmerkkijonoa
        }

        public static void GetBooksFromTenYears()
        {
            using var context = new LibraryContext();

            var currentDate = DateTime.Now;
            var books = context.Books.Where(book => currentDate.Year - book.PublicationYear <= 10).ToList();

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Publication Year: {book.PublicationYear}");
            }
        }

        public static void GetMemberHighestAge()
        {
            using var context = new LibraryContext();

            var highestAgeMember = context.Members.OrderByDescending(member => member.Syntymaaika).First();

            if (highestAgeMember != null)
            {
                var age = DateTime.Now.Year - highestAgeMember.Syntymaaika.Year;
                if (highestAgeMember.Syntymaaika > DateTime.Now.AddYears(-age))
                {
                    age--;
                }
                Console.WriteLine($"Highest Age: {age}, Member Name: {highestAgeMember.FirstName}");
            }
            else
            {
                Console.WriteLine("No members found.");
            }
        }

        public static void GetBookLowestAvailable()
        {
            using var context = new LibraryContext();

            var books = context.Books.OrderBy(book => book.AvailableCopies).First();

            if (books != null)
            {
                Console.WriteLine($"Book with least available name: {books.Title}");
            }
        }

        public static void GetMemberWithNoLoan()
        {
            using var context = new LibraryContext();

            var membersWithNoLoans = context.Members.Where(member => !context.Loans.Any(loan => loan.MemberId == member.Id)).ToList();


            foreach (var member in membersWithNoLoans)
            {
                Console.WriteLine($"Member with No Loans: {member.FirstName}");
            }
        }
    }
}
