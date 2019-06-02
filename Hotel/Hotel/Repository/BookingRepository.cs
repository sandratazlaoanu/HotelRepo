using Hotel.Connection;
using Hotel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hotel.Repository
{
    public class BookingRepository
    {
        public Booking FindOne(int id)
        {
            if (id < 0)
                return null;
            SqlConnection connection = DatabaseConnection.GetConnection();
            string select = @"dbo.[FindBooking]";
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
                        Booking booking = new Booking(int.Parse(reader["id"].ToString()), (DateTime)reader["start"], (DateTime)reader["end"], (float)reader["price"]);
                        connection.Close();
                        return booking;
                    }
                    else
                    {
                        connection.Close();
                        return null;
                    }
                }
            }

        }

        public Booking Delete(int id)
        {
            Booking Booking = FindOne(id);
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            if (Booking == null)
            {
                connection.Close();
                return null;
            }
            Booking.IsActive = false;

            connection.Close();
            return Booking;
        }

        public Booking Save(Booking Booking)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            var select = @"dbo.[CreateBooking]";

            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@id";
                param1.Value = Booking.Id;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@start";
                param2.Value = Booking.Start;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@end";
                param3.Value = Booking.End;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@isActive";
                param4.Value = Booking.IsActive;

                var param5 = cmd.CreateParameter();
                param4.ParameterName = "@price";
                param4.Value = Booking.Price;


                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);


                int affectedRows = cmd.ExecuteNonQuery();
                if (affectedRows != 0)
                { 
                    Booking booking = new Booking(Booking.Id, Booking.Start, Booking.End, Booking.Price);

                    connection.Close();
                    return booking;
                }
                else
                {
                    connection.Close();
                    return null;
                }
            }
        }

        public Booking Update(int id, Booking Booking)
        {
            Booking clon = Booking;
            if (id < 0 || Booking == null)
            {
                return null;
            }
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            string select = @"dbo.[UpdateBooking]";
            using (var cmd = new SqlCommand(select, connection))
            {
                var param1 = cmd.CreateParameter();
                param1.ParameterName = "@id";
                param1.Value = Booking.Id;

                var param2 = cmd.CreateParameter();
                param2.ParameterName = "@start";
                param2.Value = Booking.Start;

                var param3 = cmd.CreateParameter();
                param3.ParameterName = "@end";
                param3.Value = Booking.End;

                var param4 = cmd.CreateParameter();
                param4.ParameterName = "@isActive";
                param4.Value = Booking.IsActive;

                var param5 = cmd.CreateParameter();
                param4.ParameterName = "@price";
                param4.Value = Booking.Price;

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);

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

        public List<Booking> GetAll()
        {
            List<Booking> Bookings = new List<Booking>();
            string procedure = @"dbo.[GetAllBookings]";
            SqlConnection connection = DatabaseConnection.GetConnection();
            connection.Open();
            using (var cmd = new SqlCommand(procedure, connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Booking Booking = new Booking(int.Parse(reader["id"].ToString()), DateTime.Parse(reader["start"].ToString()), DateTime.Parse(reader["end"].ToString()), float.Parse(reader["price"].ToString()));
                        Bookings.Add(Booking);
                    }
                    connection.Close();
                    return Bookings;
                }
            }
        }
    }
}

