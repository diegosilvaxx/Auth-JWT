﻿using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace APIAlturas
{
    public class UsersDAO
    {
        private IConfiguration _configuration;

        public UsersDAO()
        {
        }

        public UsersDAO(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public User Find(string userID)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuration.GetConnectionString("ExemploJWT")))
            {
                return conexao.QueryFirstOrDefault<User>(
                    "SELECT UserID, AccessKey " +
                    "FROM dbo.Users " +
                    "WHERE UserID = @UserID", new { UserID = userID });
            }
        }

    }
}
