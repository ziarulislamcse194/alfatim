using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementApp.Models;

namespace StockManagementApp.Repository
{
    public class CompanyRepository
    {

        String connectionString= @"Server=DESKTOP-FGQ12CI\SQLEXPRESS;Database=StockManagement; Integrated Security=True;";
        SqlConnection sqlConnection;
        

        SqlCommand sqlCommand;

        List<DataRow> CompanyList = new List<DataRow>();
        List<int> CompanyListID = new List<int>();



       

        public int Insert(Company company)
        {



            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Insert into Companies (CompanyName) values('" + company.CompanyName + "')";

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

        public int Update(Company company)
        {

            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"update Companies set CompanyName ='" + company.CompanyName + "' Where CompanyID='" + company.ID + "'";
            sqlCommand = new SqlCommand(CommendString, sqlConnection);


            sqlConnection.Open();


            int IsOK = 0;



            IsOK = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return IsOK;

        }




        public DataTable View()
        {
            sqlConnection = new SqlConnection(connectionString);

            String CommendString = @"Select *From Companies";
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
    }
}
