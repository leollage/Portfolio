using API_Portfolio.Interfaces.Repositories;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using API_Portfolio.Model;

namespace API_Portfolio.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Product>> GetAsync()
        {
            var query = $"SELECT * FROM Produtos";

            List<Product> response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = db.QueryAsync<Product>(query, null, commandType: CommandType.Text).GetAwaiter().GetResult().OrderBy(p => p.Id).ToList();
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            var query = $"SELECT * FROM Produtos WHERE Id = {id}";

            Product response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<Product>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
        public async Task<Product> GetByNameAsync(string name)
        {
            var query = $"SELECT * FROM Produtos WHERE Name = {name}";

            Product response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<Product>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
        public async Task<int> InsertAsync(Product product)
        {
            var query = $"INSERT INTO Produtos output Inserted.ID VALUES ({product.Name}, " +
                $"{product.MinimumInvestment}, " +
                $"{product.Value}, " +
                $"{product.Vencimento})";
            int response;

            using(IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<int>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }

        public async Task<int> UpdateAsync(string id, Product product)
        {
            var query = $"UPDATE Produtos SET Name = = '{product.Name}'," +
                            $"MinimumInvestment = {product.MinimumInvestment}," +
                            $" Value = {product.Value}," +
                            $" Vencimento = {product.Vencimento}" +
                            $" WHERE id = {id}";
            int response;

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.ExecuteAsync(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }

        public async Task<int> DeleteAsync(string id)
        {
            var query = $"DELETE Produtos WHERE id = {id}";
            int response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.ExecuteAsync(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
    }
}
