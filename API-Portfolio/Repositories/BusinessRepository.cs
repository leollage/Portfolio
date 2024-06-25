using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Data.Common;

namespace API_Portfolio.Repositories
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly string _connectionString;
        public BusinessRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Product>> GetProdutosByClienteIdAsync(string clienteId)
        {
            var query = $" SELECT p.* FROM Produtos p INNER JOIN ClientesProdutos cp ON p.Id = cp.ProdutoId WHERE cp.ClienteId = {clienteId}";

            IEnumerable<Product> response;

            using (var dbConnection = new SqlConnection(_connectionString))
            {
                 response = await dbConnection.QueryAsync<Product>(query, null, commandType: CommandType.Text);
            }

            return response;

        }
        public async Task<int> InsertAsync(string clientId, string productId)
        {
            var query = $"INSERT INTO ClientesProdutos VALUES ('{clientId}', '{productId}')";
            int response;

            using (IDbConnection db = new SqlConnection(_connectionString))
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

        public async Task<int> DeleteAsync(string idClient, string idProduct)
        {
            var query = $"DELETE ClientesProdutos WHERE ClienteId = '{idClient}' and ProdutoId = '{idProduct}'";
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
