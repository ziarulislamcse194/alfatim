using StockManagementApp.BIL;
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
    class CategoriesRepository
    {

        String connectionString = @"Server=DESKTOP-FGQ12CI\SQLEXPRESS;Database=StockManagement; Integrated Security=True;";
        SqlConnection sqlConnection;


        SqlCommand sqlCommand;

        List<DataRow> CategoryList = new List<DataRow>();
        List<int> CompanyListID = new List<int>();

        public int Insert(Categories categories)
        {



            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Insert into Categories (CategoryName) values('" + categories.CategoryName + "')";

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



        public DataTable View()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Categories";
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



        public int Update(Categories categories)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"update Categories set CategoryName ='" + categories.CategoryName + "' Where CategoryID='" + categories.ID + "'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();


            int IsOK = 0;



            IsOK = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return IsOK;

        }

    }
}
