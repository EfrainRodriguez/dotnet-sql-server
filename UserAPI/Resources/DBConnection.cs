using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using UserAPI.Models;

namespace UserAPI.Resources
{
    public class DBConnection
    {
        public static string login = "Data Source=.;Initial Catalog=DVP_Test;User ID=DESKTOP-BF1O1BV\\monke;Password=root123";

        public static DataTable ListPerson(string procedure)
        {
            SqlConnection conn = new SqlConnection(login);
            Console.WriteLine(conn);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(procedure, conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable datatable = new DataTable();
                SqlDataAdapter data = new SqlDataAdapter(cmd);
                data.Fill(datatable);


                return datatable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
