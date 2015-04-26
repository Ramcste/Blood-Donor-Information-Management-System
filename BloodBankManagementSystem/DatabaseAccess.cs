using System.Data.SqlClient;

namespace BloodBankManagementSystem
{
    internal class DatabaseAccess
    {
        public SqlConnection Connection;

        public DatabaseAccess()
        {
            Connection = DatabaseConnection.GetConnection();
        }
    }
}