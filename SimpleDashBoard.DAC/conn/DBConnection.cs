using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.IO.Packaging;
using System.Security.Cryptography;
using System.Windows;
using System.Xml.Linq;

namespace SimpleDashBoard.DAC
{
    static class DBConnection
    {
        public static OracleConnection oracleConnection;
        public static OracleCommand oracleCommand;

        public static bool DBConnecter(string ip, string name, string id, StreamInfo pw)
        {
            bool value = false;

            try
            {
                oracleConnection = new OracleConnection($"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={ip})(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={name})));User ID={id};Password={pw};Connection Timeout=30;");
                oracleConnection.Open();
                oracleCommand = oracleConnection.CreateCommand();
                MessageBox.Show("Success DB Connection!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                value = true;
            } catch (Exception e)
            {
                value = false;
                MessageBox.Show($"DB Connection Fail. \n {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return value;
        }

        public static void ExecuteDataTable()
        {
            string query = $@"select * from emp";
            DataTable dataTable = new DataTable();
            oracleCommand.CommandText = query;
            using (OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(oracleCommand))
            {
                oracleDataAdapter.Fill(dataTable);
            }
        }

        public static void ExecuteDataReader()
        {
            string columnA, columnB, columnC;
            string query = $@"select * from emp";
            oracleCommand.CommandText = query;

            using (OracleDataReader oracleDataReader = new OracleDataReader)
            {
                if (oracleDataReader != null)
                {
                    while(oracleDataReader.Read()) 
                    {
                        columnA = oracleDataReader["ColumnName1"];
                        columnB = oracleDataReader
                    }
                }
            }
        }

    }
}
