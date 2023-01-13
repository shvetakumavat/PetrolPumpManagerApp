using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace PumpDataAccessLibrary.DataAccess
{
   public static class MySqlDataAccess
    {
        public static string GetConnectionString(string ConnectionName = "pumpmanagmentdb")
        {
            return ConfigurationManager.ConnectionStrings[ConnectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).ToList();
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }
    }
}
