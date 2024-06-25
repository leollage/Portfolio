using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Model;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace API_Portfolio.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        public ClientRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Client> GetByIdAsync(string id)
        {
            var query = $"SELECT * FROM Clientes WHERE Id = '{id}'";

            Client response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<Client>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
        public async Task<Client> GetByEmailAsync(string email)
        {
            var query = $"SELECT * FROM Clientes WHERE Email = '{email}'";

            Client response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<Client>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
        public async Task<Client> GetByEmailAndPasswordAsync(string email, string password)
        {
            var query = $"SELECT * FROM Clientes WHERE Email = '{email}' and Senha = '{password}'";

            Client response;
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                try
                {
                    db.Open();
                    response = await db.QueryFirstOrDefaultAsync<Client>(query, null, commandType: CommandType.Text);
                }
                finally
                {
                    if (db != null)
                        db.Close();
                }
            }
            return response;
        }
        public async Task<int> InsertAsync(Client client)
        {
            var query = $"INSERT INTO Clientes VALUES ('{client.Id}', " +
                $"'{client.Nome}', " +
                $"'{client.Email}', " +
                $"'{client.Senha}', " +
                $"{client.Idade}) ";
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

        public async Task<int> UpdateAsync(string id, Client client)
        {
            var query = $"UPDATE Clientes SET Nome = '{client.Nome}'," +
                            $" Email = '{client.Email}'," +
                            $" Senha = '{client.Senha}'," +
                            $" Idade = '{client.Idade}'" +
                            $" WHERE id = '{id}'";
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
            var query = $"DELETE Clientes WHERE id = '{id}'";
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
