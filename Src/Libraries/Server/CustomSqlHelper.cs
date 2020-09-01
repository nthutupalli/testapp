using System.Data;
using System.Data.SqlClient;

namespace Server
{
  
    
    /// <summary>
    /// CustomSqlHelper
    /// </summary>
    public static class CustomSqlHelper
    {
        /// <summary>
        /// FillDataSet
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="connectionTimeout"></param>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        /// <param name="parameters"></param>
        public static void FillDataSet(
            string connectionString,
            int connectionTimeout,
            string commandText,
            DataSet dataSet,
            SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlCommand = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = connectionTimeout,
                    CommandText = commandText
                };
                if (parameters != null)
                {
                    sqlCommand.Parameters.AddRange(parameters);
                }
                sqlCommand.Connection = connection;

                var dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataSet);
                connection.Close();
            }
        }

        /// <summary>
        /// ExecuteNonQuery
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        public static void ExecuteNonQuery(string connectionString, string commandText, SqlParameter[] parameters)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 0,
                CommandText = commandText
            };
            sqlCommand.Parameters.AddRange(parameters);
            sqlCommand.Connection = connection;
            sqlCommand.ExecuteNonQuery();
            connection.Close();
        }

        /// <summary>
        /// FillDataSet
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="connectionTimeout"></param>
        /// <param name="commandText"></param>
        /// <param name="dataSet"></param>
        public static void FillDataSet(
            string connectionString,
            int connectionTimeout,
            string commandText,
            DataSet dataSet)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var sqlCommand = new SqlCommand
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = connectionTimeout,
                CommandText = commandText,
                Connection = connection
            };

            var dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(dataSet);
            connection.Close();
        }
    }
}
