using InterferenteECO.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterferenteECO.DataAccess
{
    public class DatabaseHelper
    {
        private static readonly string connectionstring ="Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Miriam\\Documents\\Aplicatii C\\CSHARP Nationala\\InterferenteECO\\ECO.mdf\";Integrated Security=True";
        private static readonly string userspath = @"C:\Users\Miriam\Documents\Aplicatii C\CSHARP Nationala\InterferenteECO\Resurse\Useri.txt";
  
        public static void InsertUsers()
        {

            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                SqlCommand cmdDelete = new SqlCommand("Delete from Users", con);
                cmdDelete.ExecuteNonQuery();
                string cmdText = "Insert into Users values (@nume, @parola)";
                using(StreamReader reader= new StreamReader(userspath))
                {
                    while(reader.Peek()>=0)
                    {
                        string line= reader.ReadLine();
                        string[] split = line.Split(' ');
                        using(SqlCommand cmd = new SqlCommand(cmdText, con))
                        {
                            cmd.Parameters.AddWithValue("@nume", split[0]);
                            cmd.Parameters.AddWithValue("@parola", split[1]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static List<string> GetUsers() {
            List<string> users = new List<string>();
            using(SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string cmdText = "Select Name from Users";
                using(SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(reader[0].ToString());
                        }
                    }
                }
            }
            return users;
        }

        public static bool IsUser(UserModel user)
        {
            bool isUser = false;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                string cmdText = "Select * from Users where Name=@name and Password=@parola";
                using (SqlCommand cmd = new SqlCommand(cmdText, con))
                {
                    cmd.Parameters.AddWithValue("@name", user.UserName);
                    cmd.Parameters.AddWithValue("@parola", user.Password);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        if(reader.HasRows)
                        {
                            isUser = true;
                        }else isUser= false;
                    }
                }
            }
            return isUser;
        }


    }
}
