using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SAOnlineMart.Models
{
    public class Connection
    {
        public string ConnectionString { get; set; }
        private SqlConnection _ConnectionObject { get; set; }

        public Connection()
        {
            ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=onlineMart;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            _ConnectionObject = new SqlConnection();
            _ConnectionObject.ConnectionString = ConnectionString;
        }

        public DataTable queryDB(string query)
        {
            SqlCommand command = new SqlCommand(query, _ConnectionObject);
            if (!testConnection())
            {
                throw new Exception("Couldn't connect to database");
            }
            try
            {
                _ConnectionObject.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(reader);
                return dataTable;
            }
            catch
            {
                throw new Exception("Couldn't fetch items");
            }
            finally
            {
                _ConnectionObject.Close();
            }
        }

        public bool executeDB(string query)
        {
            SqlCommand command = new SqlCommand(query, _ConnectionObject);
            if (!testConnection())
            {
                throw new Exception("Couldn't connect to database");
            }
            try
            {
                _ConnectionObject.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                throw new Exception("Couldn't execute query");
            }
            finally
            {
                _ConnectionObject.Close();
            }
            return true;
        }

        public bool testConnection()
        {
            try
            {
                _ConnectionObject.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                _ConnectionObject.Close();
            }
            return true;
        }
    }
}