using System.Data.SqlClient;

namespace MiniDARMAS.Data
{
    public class DBConnection
    {
        public SqlConnection GetConnection()
        {
            string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MiniDARMAS;Integrated Security=True";
            return new SqlConnection(conn);
        }
    }
}
