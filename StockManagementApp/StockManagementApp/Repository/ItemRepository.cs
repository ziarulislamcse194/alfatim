using StockManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementApp.Repository
{
    class ItemRepository
    {
        String connectionString = @"Server=DESKTOP-FGQ12CI\SQLEXPRESS;Database=StockManagement; Integrated Security=True;";
        SqlConnection sqlConnection;


        SqlCommand sqlCommand;

        List<DataRow> CompanyList = new List<DataRow>();



        public int Insert(Item item)
        {
            
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Insert into Items (ItemName,ReorderLevel,CompanyID,CategoryID) values('" + item.ItemName + "','" + item.ReorderLevel + "','" + item.CompanyID + "','" + item.CategoryID + "')";

            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();



            int isExecuted;
            isExecuted = sqlCommand.ExecuteNonQuery();
            //int IsOK = 0;



            //IsOK = sqlCommand.ExecuteNonQuery();

            //if (IsOK > 0)
            //{
            //    MessageBox.Show("Inserted");
            //}
            //else
            //    MessageBox.Show("Not Inserted");





            sqlConnection.Close();

            return isExecuted;

        }


        public DataTable LoadCompany()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Companies";
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

        public DataTable LoadCategory()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Categories";
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



        public DataTable View()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Item";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();
            DataTable dataTable = new DataTable();

            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            if (dataReader.HasRows)
            {

                dataTable.Load(dataReader);
                //dataGridViewCompany.DataSource = dataTable;

                //foreach (DataRow dt in dataTable.Rows)
                //{
                //    CompanyList.Add(dt);
                //    richTextBox1.Text = richTextBox1.Text + dt;
                //}

            }

            sqlConnection.Close();
            return dataTable;

        }


        public DataTable Category(Company company)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select Item.CategoryName from Item where Item.CompanyName ='" + company.CompanyName+"'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            //dataGridViewCompany.DataSource = dataTable;

            //foreach (DataRow dt in dataTable.Rows)
            //{
            //    CompanyList.Add(dt);
            //    richTextBox1.Text = richTextBox1.Text + dt;
            //}

        

            sqlConnection.Close();
            return dataTable;

        }
        public DataTable Item(Categories categories)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select Item.ItemName from Item where Item.CategoryName ='" + categories.CategoryName + "'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);
            
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            
            sqlConnection.Close();
            return dataTable;

        }


        public int ReorderLavel(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select ReorderLevel from Items 
                                    where ItemName ='" + item.ItemName+"' ";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int ReorderLevel=0;
            while (sqlDataReader.Read())
            {
                ReorderLevel = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return ReorderLevel;

        }


        public int Quentity(Item item)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select Stock.StockInQuentity from Stock where Stock.ItemName='" + item.ItemName + "' ";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int Quentity = 0;
            while (sqlDataReader.Read())
            {
                Quentity = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return Quentity;
        }


        public int AvailableQuentity(Item item)
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select Stock.StockAvailable from Stock where Stock.ItemName='" + item.ItemName + "' ";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int AvailableQuentity = 0;
            while (sqlDataReader.Read())
            {
                AvailableQuentity = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return AvailableQuentity;
        }


        public int ItemId(Item item)
        {


            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"select ItemID from Items where ItemName='" + item.ItemName + "' ";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);




            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            int ItemId = 0;
            while (sqlDataReader.Read())
            {
                ItemId = sqlDataReader.GetInt32(0);
            }
            sqlConnection.Close();

            return ItemId;
        }

    }
}
