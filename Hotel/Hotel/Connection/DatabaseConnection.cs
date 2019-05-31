using System;
using System.Windows;
using System.Data.SqlClient;

namespace Hotel.Connection
{
    class DatabaseConnection
    {
            private static SqlConnection sqlCon;

            public static SqlConnection GetConnection()
            {
                sqlCon = new SqlConnection(@"Data Source=SANDRA\SANDRASQL;Initial Catalog=Hotel;Persist Security Info=True;User ID=sa;Password=1q2w3e");

                return sqlCon;
            }

            public static bool OpenConnection()
            {
                try
                {
                    sqlCon.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    MessageBox.Show("Cannot connect");
                    return false;
                }
            }

            //Close connection
            public static bool CloseConnection()
            {
                try
                {
                    sqlCon.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        
    }
}
