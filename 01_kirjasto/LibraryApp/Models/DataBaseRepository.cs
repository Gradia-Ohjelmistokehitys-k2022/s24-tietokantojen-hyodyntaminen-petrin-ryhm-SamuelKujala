using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;

namespace LibraryApp.Models
{
    public class DataBaseRepository
    {
        private string _connectionString;

        public DataBaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string IsDbConnectionEstablished()
        {
            
            using var connection = new SqlConnection(_connectionString);

            try
            {
                connection.Open();
                return "Connection established!";
            }
            catch (SqlException ex)
            {
                throw;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetBooksFromFiveYears()
        {

            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            string query = "SELECT BookId, Title, ISBN, PublicationYear, AvailableCopies FROM Book Where PublicationYear >= Year(GetDate()) - 5";
            using var command = new SqlCommand(query, dbConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book book = new()
                {
                    Id = Convert.ToInt32(reader["BookId"]),
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"].ToString())
                };

                Console.WriteLine($"{book.Id} - {book.Title} ISBN: {book.ISBN} ({book.PublicationYear})");
            }
        }

        public void GetCUstomersCenterAge()
        {
            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            string query = "SELECT AVG(DATEDIFF(YEAR, syntymaaika, GETDATE())) as keski_ika FROM Member";
            using var command = new SqlCommand(query, dbConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int keski_ika = Convert.ToInt32(reader["keski_ika"]);
                

                Console.WriteLine($"Asiakkaiden keski-ika: {keski_ika}");
            }
        }

        public void GetBookWitchContainsMost()
        {
            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            string query = "SELECT Top 1 Title, AvailableCopies FROM book Order by AvailableCopies desc";
            using var command = new SqlCommand(query, dbConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book book = new()
                {
                    Title = Convert.ToString(reader["Title"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
                };

                Console.WriteLine($"{book.Title} - Available Copies: {book.AvailableCopies}");
            }
        }

        public void GetMemberHowLoan()
        {
            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            string query = "SELECT Title, ISBN, AvailableCopies FROM Book WHERE AvailableCopies = (SELECT MAX(AvailableCopies) FROM Book)";
            using var command = new SqlCommand(query, dbConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Book Book = new()
                {
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString()
                };

                Console.WriteLine($"Book name: {Book.Title}, Book ISBN: {Book.ISBN}");
            }
        }

        public void GetThreeMostLoanBook()
        {
            using var dbConnection = new SqlConnection(_connectionString);
            dbConnection.Open();

            string query = "SELECT TOP 1 loan.BookID, book.Title, book.ISBN, book.PublicationYear, book.AvailableCopies FROM Book book JOIN Loan loan ON book.BookID = loan.BookID GROUP BY loan.BookID, book.Title, book.ISBN, book.PublicationYear, book.AvailableCopies ORDER BY COUNT(loan.BookID) DESC";
            using var command = new SqlCommand(query, dbConnection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Loan Loan = new()
                {
                    BookId = Convert.ToInt32(reader["BookID"])
                };

                Book book = new()
                {
                    Title = reader["Title"].ToString(),
                    ISBN = reader["ISBN"].ToString(),
                    PublicationYear = Convert.ToInt32(reader["PublicationYear"]),
                    AvailableCopies = Convert.ToInt32(reader["AvailableCopies"])
                };

                Console.WriteLine($"Book ID: {Loan.BookId}, Book Name: {book.Title}, Book ISBN: {book.ISBN}, Book PublicationYear: {book.PublicationYear}, Book AvailableCopies: {book.AvailableCopies}");
            }
        }
    }
}
