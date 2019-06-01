using Hotel.Connection;
using Hotel.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Repository
{
    class RoomRepository
    {
        public Room FindOne(int id)
        {
            if (id < 0)
                return null;
            SqlConnection connection = DatabaseConnection.GetConnection();
            string select = @"dbo.[FindRoom]";
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
                        Room Room = new Room(int.Parse(reader["id"].ToString()), (string)reader["type"].ToString(), (bool)reader["isAvailable"], (float)reader["price"]);
                        connection.Close();
                        return Room;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }

        }

        public Room Delete(int id)
        {
            Room Room = FindOne(id);
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            if (Room == null)
            {
                connection.Close();
                return null;
            }
            Room.IsAvailable = false;

            connection.Close();
            return Room;
        }

        public Room Save(Room Room)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            var select = @"dbo.[CreateRoom]";

            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@id";
                param1.Value = Room.Id;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@type";
                param2.Value = Room.Type;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@isAvailable";
                param3.Value = Room.IsAvailable;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@standardPrice";
                param4.Value = Room.StandardPrice;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);

                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 0)
                {

                    Room room = new Room(Room.Id, Room.Type, Room.IsAvailable, Room.StandardPrice);
                    connection.Close();
                    return room;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }


        }


        public Room Update(int id, Room Room)
        {
            Room clon = Room;
            if (id < 0 || Room == null)
            {
                return null;
            }
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            string select = @"dbo.[UpdateRoom]";
            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@type";
                param1.Value = Room.Type;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@isAvailable";
                param2.Value = Room.IsAvailable;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@standardPrice";
                param3.Value = Room.StandardPrice;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
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

        public List<Room> GetAll()
        {
            List<Room> rooms = new List<Room>();
            string procedure = @"dbo.[GetAllRooms]";
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using (var cmd = new SqlCommand(procedure, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Room room = new Room(int.Parse(reader["id"].ToString()), (string)reader["type"].ToString(), (bool)reader["isAvailable"], float.Parse(reader["standardPrice"].ToString()));
                        rooms.Add(room);
                    }
                    connection.Close();
                    return rooms;
                }
            }
        }

        public int LastIndex()
        {
            List<Room> Rooms = GetAll();
            int index = Rooms.Capacity + 1;
            return index;

        }
    }
}

