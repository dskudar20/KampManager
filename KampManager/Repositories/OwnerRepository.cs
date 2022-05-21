using DBLayer;
using KampManager.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KampManager.Repositories
{
    public class OwnerRepository
    {
        public static Owner GetOwner(string username)
        {
            string sql = $"SELECT * FROM Owners WHERE UserName = '{username}'";
            return FetchOwner(sql);
        }

        public static Owner GetOwner(int id)
        {
            string sql = $"SELECT * FROM Owners WHERE OwnerId = {id}";
            return FetchOwner(sql);
        }

        private static Owner FetchOwner(string sql)
        {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Owner owner = null;

            if(reader.HasRows == true)
            {
                reader.Read();
                owner = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();

            return owner;
        }

        private static Owner CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["OwnerId"].ToString());
            string FirstName = reader["OwnerFirstName"].ToString();
            string LastName = reader["OwnerLastName"].ToString();
            string username = reader["UserName"].ToString();
            string password = reader["Password"].ToString();

            var owner = new Owner
            {
                Id = id,
                FirstName = FirstName,
                LastName = LastName,
                Username = username,
                Password = password
            };

            return owner;
        }


    }
}
