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

            var category = new Category();
            category.Id = Guid.NewGuid();
            category.Title = "Amazon AWS";
            category.Url = "amazon";
            category.Description = "Categoria destinada a serviços do AWS";
            category.Order = 8;
            category.Summary = "AWS Cloud";
            category.Featured = false;

            //SQL Injection


            var insertSql = @"INSERT INTO 
                    [Category] 
                values(
                    id, 
                    title, 
                    url, 
                    summary, 
                    order, 
                    description, 
                    featured)";


            using (var connection = new SqlConnection(connectionString))
            {
                var categories = connection.Query<Category>("SELECT [Id], [Title] FROM [Category]");
                foreach (var item in categories)
                {
                    System.Console.WriteLine($"{item.Id} - {item.Title}");
                }
            }

        }
    }
}
