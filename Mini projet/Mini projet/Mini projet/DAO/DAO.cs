using System.Data;
using System.Data.SqlClient;

namespace Mini_projet.DAO
{
    abstract class DAO
    {
        private const string CONNEC_STRING =
            "Data Source=sqlserver;" +
            "Database=*************;" +
            "User ID=invite11;" +
            "Password=l3si";

        private DataSet dataset;
        private SqlDataAdapter adapter;
        protected SqlConnection connection;

        public DAO()
        {
            connection = new SqlConnection(CONNEC_STRING);
            connection.Open();

            // ...

            connection.Close();

            // ...
        }
    }
}
