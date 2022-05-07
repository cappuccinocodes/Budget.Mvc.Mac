using System;
using System.Data;
using Budget.Mvc.Mac.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace Budget.Mvc.Mac.Repositories
{
	public interface IBudgetRepository
	{
		List<Category> GetCategories();

		List<Transaction> GetTransactions();
		void AddTransaction(Transaction transaction);
		void UpdateTransaction(Transaction transaction);
		void DeleteTransaction(int id);

	}

	public class BudgetRepository: IBudgetRepository
	{
		private readonly IConfiguration _configuration;

		public BudgetRepository(IConfiguration configuration)
		{
			_configuration = configuration;
		}

        public void AddTransaction(Transaction transaction)
        {
			using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
			{
				var sql = "INSERT INTO Transactions(Name, Date, Amount, TransactionType, CategoryId ) Values(@Name, @Date, @Amount, @TransactionType, @CategoryId )";
				connection.Execute(sql, transaction);
			}
		}

        public void DeleteTransaction(int id)
        {
			using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
			{
				var sql = "DELETE FROM Transactions WHERE Id = @id";
				connection.Execute(sql, new { id });
			}
		}

        public List<Category> GetCategories()
        {
			using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
			{
				var query = @"SELECT * FROM Category";

				var categories = connection.Query<Category>(query).ToList();

				return categories;
			}
		}

        public List<Transaction> GetTransactions()
		{
			using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
			{
				var query =
					@"SELECT t.Amount, t.CategoryId, t.[Date], t.Id, t.TransactionType, t.Name, c.Name AS Category
                      FROM Transactions AS t
                      LEFT JOIN Category AS c
                      ON t.CategoryId = c.Id;";

				var allTransactions = connection.Query<Transaction>(query);

				return allTransactions.ToList();
			}
		}

        public void UpdateTransaction(Transaction transaction)
        {
			using (IDbConnection connection = new SqliteConnection(_configuration.GetConnectionString("ConnectionString")))
			{
				var sql =
					@"UPDATE Transactions
                          SET Date = @Date, Amount = @Amount, Name = @Name, CategoryId = @CategoryId, TransactionType = @TransactionType
                          WHERE Id = @Id";

				connection.Execute(sql, transaction);
			}
		}
    }
}

