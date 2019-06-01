using Hotel.Connection;
using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Repository
{
    class ExtraServiceRepository
    {
        public ExtraService FindOne(int id)
        {
            if (id < 0)
                return null;
            SqlConnection connection = DatabaseConnection.GetConnection();
            string select = @"dbo.[FindService]";
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
                        ExtraService ExtraService = new ExtraService(int.Parse(reader["id"].ToString()), (string)reader["type"].ToString(),(float)reader["price"]);
                        connection.Close();
                        return ExtraService;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }

        }

        public ExtraService Delete(int id)
        {
            ExtraService ExtraService = FindOne(id);
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            if (ExtraService == null)
            {
                connection.Close();
                return null;
            }

            connection.Close();
            return ExtraService;
        }

        public ExtraService Save(ExtraService ExtraService)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            var select = @"dbo.[CreateService]";

            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@id";
                param1.Value = ExtraService.Id;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@type";
                param2.Value = ExtraService.Type;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@price";
                param4.Value = ExtraService.Price;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param4);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 0)
                {

                    ExtraService extraService = new ExtraService(ExtraService.Id, ExtraService.Type, ExtraService.Price);
                    connection.Close();
                    return extraService;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }


        }


        public ExtraService Update(int id, ExtraService ExtraService)
        {
            ExtraService clon = ExtraService;
            if (id < 0 || ExtraService == null)
            {
                return null;
            }
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            string select = @"dbo.[UpdateService]";
            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@type";
                param1.Value = ExtraService.Type;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@price";
                param3.Value = ExtraService.Price;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param3);
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

        public List<ExtraService> GetAll()
        {
            List<ExtraService> extraServices = new List<ExtraService>();
            string procedure = @"dbo.[GetAllExtraServices]";
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using (var cmd = new SqlCommand(procedure, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ExtraService extraService = new ExtraService(int.Parse(reader["id"].ToString()), (string)reader["type"].ToString(), float.Parse(reader["price"].ToString()));
                        extraServices.Add(extraService);
                    }
                    connection.Close();
                    return extraServices;
                }
            }
        }

        public int LastIndex()
        {
            List<ExtraService> extraServices = GetAll();
            int index = extraServices.Capacity + 1;
            return index;

        }
    }
}
