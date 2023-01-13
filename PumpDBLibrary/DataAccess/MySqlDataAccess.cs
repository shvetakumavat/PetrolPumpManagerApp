using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using Dapper;
using System.Linq;

namespace PumpDBLibrary.DataAccess
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

        public static T LoadValue<T>(string sql)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql).FirstOrDefault();
            }
        }
        public static void DeleteData(string sql, int id=0)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {

             cnn.Query(sql,id);
            }
        }
        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {

                return cnn.Execute(sql, data);
            }
        }


        //update Method for getting data from DBMS
        public static List<T> ExecuteStoredProcedures <T> (string sql, string [] parameters,params object[] val)
        {
           
            using (IDbConnection cnn = new MySqlConnection(GetConnectionString()))
            {
                var p = new DynamicParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    p.Add(parameters[i], val[i]);
                }
               return  cnn.Query<T>(sql, p, commandType: CommandType.StoredProcedure).ToList();
            }
           
        }
    }
}
