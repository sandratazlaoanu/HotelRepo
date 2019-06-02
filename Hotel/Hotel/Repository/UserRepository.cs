using Hotel.Connection;
using Hotel.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Repository
{
    class UserRepository
    { 
   
        public User FindOne(int id)
        {
            if (id < 0)
                return null;
            SqlConnection connection = DatabaseConnection.GetConnection();
            string select = @"dbo.[FindUser]";
            connection.Open();
            using (var cmd = new SqlCommand(select, connection))
            {
                var param = cmd.CreateParameter();
                param.ParameterName = "id";
                param.Value = id;
                cmd.Parameters.Add(param);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        User user = new User(int.Parse(reader["id"].ToString()), (string)reader["username"].ToString(), (string)reader["password"].ToString(),(string)reader["type"].ToString());
                        connection.Close();
                        return user;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }

        }

        public User Delete(int id)
        {
            User User = FindOne(id);
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            if (User == null)
            {
                connection.Close();
                return null;
            }
            User.IsActive = false;

            connection.Close();
            return User;



        }

        public User Save(User User)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            var select = @"dbo.[CreateUser]";

            using (var cmd = new SqlCommand(select, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@username";
                param1.Value = User.Username;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@password";
                param2.Value = User.Password;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@type";
                param3.Value = User.Type;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@isActive";
                param4.Value = User.IsActive;
            
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 0)
                {

                    User user = new User(User.Id, User.Username, User.Password, User.Type);
                    connection.Close();
                    return user;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }


        }


        public User Update(int id, User user)
        {
            User clon = user;
            if (id < 0 || user == null)
            {
                return null;
            }
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            string select = @"dbo.[UpdateUser]";
            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@username";
                param1.Value = user.Username;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@password";
                param2.Value = user.Password;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@type";
                param3.Value = user.Type;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@isActive";
                param4.Value = user.IsActive;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);

                int affectedRows = cmd.ExecuteNonQuery();


                if (affectedRows != 0)
                {
                    connection.Close();
                    return clon;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> Useri = new List<User>();
            string procedure = @"dbo.[GetUserList]";
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using (var cmd = new SqlCommand(procedure, connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User angaj = new User(int.Parse(reader["id"].ToString()), (string)reader["username"].ToString(), (string)reader["password"].ToString(), (string)reader["type"].ToString());
                        Useri.Add(angaj);
                    }
                    connection.Close();
                    return Useri;
                }
            }
        }
    }
}

