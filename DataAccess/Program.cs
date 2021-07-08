using System;
using Dapper;
using Microsoft.Data.SqlClient;
using DataAccess.Models;

// Dapper

namespace DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Server=localhost, 1433; Database=baltaio;User ID=sa;Password=1q2w3e4r@#$";
            // Microsoft.Data.SqlClient (Nuget)

            using (var connection = new SqlConnection(connectionString))
            {
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var category in categories)
                {
                    System.Console.WriteLine($"{category.Id} - {category.Title}");
                }
            }

        }
    }
}
