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
                    MessageBox.Show("Cannot connect");
                    return false;
                }
            }

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
