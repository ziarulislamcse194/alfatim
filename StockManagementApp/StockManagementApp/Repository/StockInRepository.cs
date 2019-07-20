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
    class StockInRepository
    {
        String connectionString = @"Server=DESKTOP-FGQ12CI\SQLEXPRESS;Database=StockManagement; Integrated Security=True;";
        SqlConnection sqlConnection;


        SqlCommand sqlCommand;

        public int Insert(StockIn stockIn)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Insert into StockIn (StockInQuentity,StockInDate,ItemID,StockAvailable) values ('" + stockIn.StockInQuentity + "','" + stockIn.StockInDate + "','" + stockIn.ItemID + "','" + stockIn.StockAvailableQuentity + "')";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();



            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            




            sqlConnection.Close();

            return isExecuted;

        }

        public void Updatequentity(StockIn stockIn)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"UPDATE StockIn SET StockInQuentity = '" + stockIn.StockInQuentity + "',StockAvailable='" + stockIn.StockAvailableQuentity+"' WHERE StockInID = '" + stockIn.StockInID + "';";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();




            sqlCommand.ExecuteNonQuery();





            sqlConnection.Close();



        }

        public int GetID(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select Stock.StockInID from Stock where Stock.ItemName='" + item.ItemName + "' ";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int GetID = 0;
            while (sqlDataReader.Read())
            {
                GetID = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return GetID;
        }
        public void Update(StockIn stockIn)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"UPDATE StockIn SET StockAvailable = '"+stockIn.StockAvailableQuentity+"' WHERE StockInID = '"+stockIn.StockInID+"';";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();



           
           sqlCommand.ExecuteNonQuery();





            sqlConnection.Close();

           

        }



        public DataTable Search(Company company,Categories categories)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select I.ItemName, s.StockAvailable,I.ReorderLevel,I.CompanyName,I.CategoryName from StockIn as S join Item as I on I.ItemID=S.ItemID where (I.CompanyName='" + company.CompanyName+ "') and (I.CategoryName='"+categories.CategoryName+"')";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (sqlDataAdapter.HasRows)
            //{

            //    dataTable.Load(sqlDataAdapter);
            //    //dataGridViewCompany.DataSource = dataTable;

            //    //foreach (DataRow dt in dataTable.Rows)
            //    //{
            //    //    CompanyList.Add(dt);
            //    //    richTextBox1.Text = richTextBox1.Text + dt;
            //    //}

            //}

            sqlConnection.Close();
            return dataTable;

        }

        public DataTable LoadStock()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select S.StockInID as SL,I.ItemName,S.StockInQuentity,s.StockInDate from StockIn as S join Item as I on I.ItemID=S.ItemID";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            //if (sqlDataAdapter.HasRows)
            //{

            //    dataTable.Load(sqlDataAdapter);
            //    //dataGridViewCompany.DataSource = dataTable;

            //    //foreach (DataRow dt in dataTable.Rows)
            //    //{
            //    //    CompanyList.Add(dt);
            //    //    richTextBox1.Text = richTextBox1.Text + dt;
            //    //}

            //}

            sqlConnection.Close();
            return dataTable;

        }


    }
}
