using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using StockManagementApp.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementApp.Repository
{
    class StockOutRepository
    {
        String connectionString = @"Server=DESKTOP-FGQ12CI\SQLEXPRESS;Database=StockManagement; Integrated Security=True;";
        SqlConnection sqlConnection;


        SqlCommand sqlCommand;


        public int Insert(StockOut stockOut)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Insert into StockOut (StockOutQuentity,StockOutDate,ItemID,StockOutStatus) values ('" + stockOut.StockOutQuentity + "','" + stockOut.StockOutDate + "','" + stockOut.ItemID + "','" + stockOut.StockOutStatus + "')";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();



            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            

            sqlConnection.Close();

            return isExecuted;

        }


        public DataTable LoadStockout()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select s.StockOutID,i.CompanyName,s.StockOutQuentity From StockOut as s join Item as I on I.ItemID=S.ItemID";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

           

            sqlConnection.Close();
            return dataTable;

        }


        public DataTable GetRiport(StockOut stockOut)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select I.ItemName, i.CompanyName,StockOut.StockOutQuentity as DamageLostSellQuentity FROM (select * FROM StockOut  where StockOutStatus= '"+stockOut.StockOutStatus+"') StockOut join Item as I on I.ItemID=StockOut.ItemID    where StockOutDate between '"+stockOut.StartDate+"' and '"+stockOut.EndDate+"'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);
            
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);



            sqlConnection.Close();
            return dataTable;

        }
    }
}
