using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Specialized;
using System.Data;
using WebApplication5.Entity;

namespace WebApplication5.Repositories
{
    public class UserRepository
    {
        public string ConnectionString = "Data Source=DESKTOP-39A9U0N\\SQLEXPRESS;User ID=admin;Password=123@123@; database=Users; TrustServerCertificate=True;";

        public async Task<int> Create(User user)
        {
            int insertedRows = 0;
            try
            {
                string query = $"INSERT INTO [dbo].[UserTable] ([Name],[Surname],[ThirdName] ,[Email],[DateOfBirth],[CreatedDate]) VALUES  (@Name, @Surname, @ThirdName, @Email, @DateOfBrith, SYSDATETIME())";
                
                //var commandDefinition = new CommandDefinition(query, new { user }); таким оброзам не получилось 
                IDbConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                insertedRows = await connection.ExecuteAsync(query, user);//поэтому сделал таким
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return insertedRows;
        }

        public async Task<int> Update(User user)
        {
            int insertedRows = 0;
            try
            {
                string query = $"UPDATE [dbo].[UserTable]  SET [Name] = @Name, [Surname] = @Surname ,[ThirdName] = @ThirdName ,[Email] = @Email, [DateOfBirth] = @DateOfBrith WHERE ID = @id";
                //var commandDefinition = new CommandDefinition(query, new { user });
                IDbConnection connection = new SqlConnection(ConnectionString);
                connection.Open();
                insertedRows = await connection.ExecuteAsync(query, user);
                connection.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return insertedRows;
        }
        public async Task Delete(int id)
        {
            try
            {
                string query = $"DELETE FROM [dbo].[UserTable]  WHERE ID = @Id";
                var commandDefinition = new CommandDefinition(query, new {  id });
                var connection = new SqlConnection(ConnectionString);
                connection.Open();
                await connection.ExecuteAsync(commandDefinition);
                connection.Close();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async Task<List<User>> GetAll()
        {
            string query = $"SELECT [ID],[Name],[Surname],[ThirdName],[Email],[DateOfBirth],[CreatedDate] FROM [dbo].[UserTable]";
            var commandDefinition = new CommandDefinition(query );
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var result = await connection.QueryAsync<User>(query);
            return result.ToList();
            connection.Close();
        }
        public async Task<List<User>> GetById(int ID)
        {
            string query = $"SELECT [ID], [Name] ,[Surname],[ThirdName],[Email],[DateOfBirth],[CreatedDate] FROM [dbo].[UserTable] WHERE ID = @ID";
            var commandDefinition = new CommandDefinition(query, new { ID });
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var result = await connection.QueryAsync<User>(commandDefinition);
            return result.ToList();
            //return connection.Query<User>(commandDefinition).ToList();
            //connection.Close();
        }
        
    }
}
