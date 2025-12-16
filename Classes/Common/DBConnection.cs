

using System.Data.OleDb;

namespace praktika15.Classes.Common
{
    public class DBConnection
    {
        public static readonly string Path = @"C:\Users\kenn1d\Documents\Учёба\3 курс\05.02\praktika15\bin\Debug\DataBase.accdb";
        public static OleDbConnection Connection()
        {
            OleDbConnection connection = new OleDbConnection(Path);
            connection.Open();

            return connection;
        }

        public static OleDbDataReader Query(string sql, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand(sql, connection);
            return command.ExecuteReader();
        }

        public static void CloseConnection(OleDbConnection connection) {
            connection.Close();
        }
    }
}
