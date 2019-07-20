using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Sql;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using StockManagementApp.Models;
using StockManagementApp.BIL;

namespace StockManagementApp
{
    public partial class StockManagement : Form
    {
        public StockManagement()
        {
            InitializeComponent();
            
        }

        int M;
        int X;
        int Y;

        List<DataRow> CompanyList = new List<DataRow>();
        List<DataRow> categoryList = new List<DataRow>();


        Company company = new Company();
        CompanyManager _companyManager = new CompanyManager();

        Categories categories = new Categories();
        CategoryManager _categoryManager = new CategoryManager();

        Item item = new Item();
        ItemManager _itemManager = new ItemManager();

        StockIn stockIn = new StockIn();
        StockInManager _stockInManager = new StockInManager();

        StockOut stockOut = new StockOut();
        StockOutManager _stockOutManager = new StockOutManager();



        private void buttonCompanyAdd_Click(object sender, EventArgs e)
        {
            try
            {

                

                company.CompanyName = textBoxCompany.Text;
                if (company.CompanyName == "")
                {
                    MessageBox.Show("Insert A Company Name");
                    return;
                }
                
               

               else if (IsExsist(company) == false)
                {

                    if (buttonCompanyAdd.Text=="Add")
                    {
                        int IsOK = 0;

                        IsOK = _companyManager.CompanyIn(company);

                       

                        if (IsOK > 0)
                        {
                            MessageBox.Show("Inserted");
                        }
                        else
                        {
                            MessageBox.Show("Not Inserted");
                        }
                        dataGridViewCompany.DataSource = _companyManager.View();

                        foreach (DataRow dt in _companyManager.View().Rows)
                        {
                            CompanyList.Add(dt);
                           
                        }



                    }

                    else
                    {
                        int IsOK = 0;

                        IsOK = _companyManager.CompanyUpdate(company);
                        
                       

                        if (IsOK > 0)
                        {
                            MessageBox.Show("Updated");
                            buttonCompanyAdd.Text = "Add";
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                        dataGridViewCompany.DataSource = _companyManager.View();

                        foreach (DataRow dt in _companyManager.View().Rows)
                        {
                            CompanyList.Add(dt);
                           
                        }

                    }

                    
                   
                }

                else if (IsExsist(company) == true)
                {
                    MessageBox.Show("Already Have!");
                }

                else
                {
                    MessageBox.Show("SomeThing unexpected!");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }



        }

       
        

        bool IsExsist(Company company)
        {
            bool isok = false;
            foreach (DataRow item in CompanyList)
            {
                if (company.CompanyName == item[1].ToString())
                {

                    isok = true;
                }


            }


            return isok;
        }





        bool IsExsist(Categories categories)
        {
            bool isok = false;
            foreach (DataRow item in categoryList)
            {
                if (categories.CategoryName == item[1].ToString())
                {

                    isok = true;
                }


            }


            return isok;
        }



        private void StockManagement_Load(object sender, EventArgs e)
        {


            Tab.SelectTab(tabPage7);
            buttonTabpage1.Enabled=false;
            buttonTabPage2.Enabled = false;
            buttonTabPage3.Enabled = false;
            buttonTabPage4.Enabled = false;
            buttonTabPage5.Enabled = false;
            buttonTabPage6.Enabled = false;

        }

        

        private void dataGridViewCompany_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBoxCompany.Text = dataGridViewCompany.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                company.ID = Convert.ToInt32(dataGridViewCompany.Rows[e.RowIndex].Cells[0].Value);

                buttonCompanyAdd.Text = "Edit";
            }
            

               catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        
        }

        private void buttonCategoryAdd_Click(object sender, EventArgs e)
        {


            try
            {



                categories.CategoryName = textBoxCategory.Text;
                if (categories.CategoryName == "")
                {
                    MessageBox.Show("Insert A Category Name");
                    return;
                }



                else if (IsExsist(categories) == false)
                {

                    if (buttonCategoryAdd.Text == "Add")
                    {
                        int IsOK = 0;

                        IsOK = _categoryManager.Insert(categories);



                        if (IsOK > 0)
                        {
                            MessageBox.Show("Inserted");
                        }
                        else
                        {
                            MessageBox.Show("Not Inserted");
                        }
                        dataGridViewCategory.DataSource = _categoryManager.View();

                        foreach (DataRow dt in _categoryManager.View().Rows)
                        {
                            categoryList.Add(dt);

                        }



                    }

                    else
                    {
                        int IsOK = 0;

                        IsOK = _categoryManager.Update(categories);



                        if (IsOK > 0)
                        {
                            MessageBox.Show("Updated");
                            buttonCategoryAdd.Text = "Add";
                        }
                        else
                        {
                            MessageBox.Show("Not Updated");
                        }
                        dataGridViewCategory.DataSource = _categoryManager.View();

                        foreach (DataRow dt in _categoryManager.View().Rows)
                        {
                            categoryList.Add(dt);

                        }

                    }



                }

                else if (IsExsist(categories) == true)
                {
                    MessageBox.Show("Already Have!");
                }

                else
                {
                    MessageBox.Show("SomeThing unexpected!");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }


        }

        private void dataGridViewCategory_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxCategory.Text = dataGridViewCategory.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            categories.ID = Convert.ToInt32(dataGridViewCategory.Rows[e.RowIndex].Cells[0].Value);

            buttonCategoryAdd.Text = "Edit";
        }

        private void buttonItemAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxItem.Text!="")
                { 
                    item.ItemName = textBoxItem.Text;
                    item.ReorderLevel = Convert.ToInt32(textBoxItemReorder.Text);
                    item.CompanyID = (comboBoxItemCompany.SelectedIndex) + 1;

                    item.CategoryID = (comboBoxItemCategory.SelectedIndex) + 1;

                    if (textBoxItem.Text != "" && textBoxItemReorder.Text != "")
                    {
                        _itemManager.insert(item);

                        MessageBox.Show("Ok");

                        dataGridViewItem.DataSource = _itemManager.View();
                    }
                }
                else
                {
                    MessageBox.Show("Not Allow Null");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
           

        }

        private void comboBoxStockInCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            company.CompanyName =comboBoxStockInCompany.Text;
            comboBoxStockInCategory.DataSource = _itemManager.Category(company);
            comboBoxStockInCategory.SelectedValue = "";
        }
        
        private void comboBoxStockInCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            categories.CategoryName = comboBoxStockInCategory.Text;
            comboBoxStockInItem.DataSource = _itemManager.Item(categories);
            comboBoxStockInItem.SelectedValue = "";
        }

        private void buttonStockIn_Click(object sender, EventArgs e)
        {
            try
            {
                if (stockIntextBox.Text != "")
                {
                    if (buttonStockIn.Text == "Add")

                    {
                        stockIn.StockInDate = DateTime.Today;
                        stockIn.StockInQuentity = Convert.ToInt32(stockIntextBox.Text);
                        stockIn.StockAvailableQuentity = stockIn.StockAvailableQuentity + stockIn.StockInQuentity;



                       
                            _stockInManager.Insert(stockIn);

                            MessageBox.Show("Inserted");

                            dataGridViewStockIn.DataSource = _stockInManager.LoadStock();
                        
                    }

                    else
                    {
                        stockIn.StockInDate = DateTime.Today;
                        stockIn.StockInQuentity = Convert.ToInt32(stockIntextBox.Text);
                        stockIn.StockAvailableQuentity = stockIn.StockAvailableQuentity + stockIn.StockInQuentity;

                        _stockInManager.Updatequentity(stockIn);
                        dataGridViewStockIn.DataSource = _stockInManager.LoadStock();
                        buttonStockIn.Text = "Add";
                    }
                }

                else
                {
                    MessageBox.Show("Null value not allow");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
            



        }

        private void comboBoxStockInItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ItemName = comboBoxStockInItem.Text;
            reorderleveltextBox.Text = _itemManager.ReorderLavel(item).ToString();
            stockIn.ItemID = _itemManager.ItemId(item);
            stockIn.StockAvailableQuentity= _itemManager.AvailableQuentity(item);
            avaiabletextBox.Text = stockIn.StockAvailableQuentity.ToString();

           
        }

        private void Tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab.SelectedTab == tabPage2)
            {
                dataGridViewCompany.DataSource = _companyManager.View();

                foreach (DataRow dt in _companyManager.View().Rows)
                {
                    CompanyList.Add((dt));
                }

            }

            if (Tab.SelectedTab == tabPage1)
            {
                dataGridViewCategory.DataSource = _categoryManager.View();
                foreach (DataRow dt in _categoryManager.View().Rows)
                {
                    categoryList.Add((dt));
                }

            }

            if (Tab.SelectedTab == tabPage3)
            {
                
                dataGridViewItem.DataSource = _itemManager.View();
                comboBoxItemCompany.DataSource = _itemManager.loadCompany();
                comboBoxItemCategory.DataSource = _itemManager.loadCategory();
                
            }

            if (Tab.SelectedTab == tabPage4)
            {
               

                comboBoxStockInCompany.DataSource = _itemManager.loadCompany();
                comboBoxStockInCompany.SelectedValue = "";
                dataGridViewStockIn.DataSource = _stockInManager.LoadStock();
            }

            if (Tab.SelectedTab == tabPage5)
            {
                comboBoxStockOutCompany.DataSource = _itemManager.loadCompany();
                comboBoxStockOutCompany.SelectedValue = "";
                dataGridViewStockOut.DataSource = _stockOutManager.StockOut();
            }

            if (Tab.SelectedTab == tabPage6)
            {
                comboBoxSearchCompany.DataSource = _itemManager.loadCompany();
                comboBoxSearchCetegory.DataSource = _itemManager.loadCategory();
            }


        }

        private void comboBoxStockOutCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            categories.CategoryName = comboBoxStockOutCategory.Text;
            comboBoxStockOutItem.DataSource = _itemManager.Item(categories);
            comboBoxStockOutItem.SelectedValue = "";

           
        }

        private void comboBoxStockOutCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            company.CompanyName = comboBoxStockOutCompany.Text;
            comboBoxStockOutCategory.DataSource = _itemManager.Category(company);
            comboBoxStockOutCategory.SelectedValue = "";

        }

        private void comboBoxStockOutItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            item.ItemName = comboBoxStockOutItem.Text;
            textBoxStockOutReorder.Text = _itemManager.ReorderLavel(item).ToString();
            stockOut.ItemID = _itemManager.ItemId(item);
            stockIn.StockAvailableQuentity = _itemManager.Quentity(item);
            textBoxStockOutQuentity.Text = _itemManager.AvailableQuentity(item).ToString();
            stockIn.StockInID = _stockInManager.GetID(item);

        }

        private void buttonStockOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxStockOutQuentity.Text != "")
                { int chack = Convert.ToInt32(textBoxStockOutQuentity.Text) - Convert.ToInt32(textBoxStockOut.Text);

                    if (chack <= Convert.ToInt32(textBoxStockOutReorder.Text))
                    {
                        MessageBox.Show("Under Reorder Level");
                    }
                    else
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Item");
                        dt.Columns.Add("Company");
                        dt.Columns.Add("Quentity");
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                        for (int i = 0; i <= 2; i++)
                        {
                            dr["Item"] = item.ItemName;
                            dr["Company"] = company.CompanyName;
                            dr["Quentity"] = textBoxStockOut.Text;

                        }
                        dataGridViewStockOut.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("Not Allow Null");
                }
            }
            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
           



           
        }

        private void StockOutSellbutton_Click(object sender, EventArgs e)
        {
            stockOut.StockOutDate = DateTime.Today;
            stockOut.StockOutQuentity = Convert.ToInt32(textBoxStockOut.Text);
            stockOut.StockOutStatus = StockOutSellbutton.Text;
            _stockOutManager.Insert(stockOut);
            dataGridViewStockOut.DataSource = _stockOutManager.StockOut();

            stockIn.StockAvailableQuentity = _itemManager.AvailableQuentity(item) - stockOut.StockOutQuentity;
            _stockInManager.Update(stockIn);

        }

        private void StockOutDamagebutton_Click(object sender, EventArgs e)
        {
            stockOut.StockOutDate = DateTime.Today;
            stockOut.StockOutQuentity = Convert.ToInt32(textBoxStockOut.Text);
            stockOut.StockOutStatus = StockOutDamagebutton.Text;
            _stockOutManager.Insert(stockOut);
            dataGridViewStockOut.DataSource = _stockOutManager.StockOut();

            stockIn.StockAvailableQuentity = _itemManager.AvailableQuentity(item) - stockOut.StockOutQuentity;
            _stockInManager.Update(stockIn);
        }

        private void StockOutLosebutton_Click(object sender, EventArgs e)
        {
            stockOut.StockOutDate = DateTime.Today;
            stockOut.StockOutQuentity = Convert.ToInt32(textBoxStockOut.Text);
            stockOut.StockOutStatus = StockOutLosebutton.Text;
            _stockOutManager.Insert(stockOut);
            dataGridViewStockOut.DataSource = _stockOutManager.StockOut();

            stockIn.StockAvailableQuentity = _itemManager.AvailableQuentity(item) - stockOut.StockOutQuentity;
            _stockInManager.Update(stockIn);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            company.CompanyName = comboBoxSearchCompany.Text;
            categories.CategoryName = comboBoxSearchCetegory.Text;

            dataGridViewSearchCetegory.DataSource = _stockInManager.Search(company, categories);
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            if(radioButtonReportSell.Checked)
            {
                stockOut.StockOutStatus = radioButtonReportSell.Text;
            }
            else if (radioButtonReportDamge.Checked)
            {
                stockOut.StockOutStatus = radioButtonReportDamge.Text;
            }
            else if (radioButtonReportLost.Checked)
            {
                stockOut.StockOutStatus = radioButtonReportLost.Text;
            }

            stockOut.StartDate = dateTimePickerReportFrom.Value;
            stockOut.EndDate = dateTimePickerReportTo.Value;


            dataGridViewReport.DataSource = _stockOutManager.GetRiport(stockOut);

        }

        private void buttonTabpage1_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(tabPage2);
            buttonTabpage1.BackColor = Color.LightGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
            buttonTabPage3.BackColor = Color.LightSlateGray;
            buttonTabPage4.BackColor = Color.LightSlateGray;
            buttonTabPage5.BackColor = Color.LightSlateGray;
            buttonTabPage6.BackColor = Color.LightSlateGray;
        }

        private void buttonTabPage2_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(tabPage1);
            buttonTabpage1.BackColor = Color.LightSlateGray;
            buttonTabPage2.BackColor = Color.LightGray;
            buttonTabPage3.BackColor = Color.LightSlateGray;
            buttonTabPage4.BackColor = Color.LightSlateGray;
            buttonTabPage5.BackColor = Color.LightSlateGray;
            buttonTabPage6.BackColor = Color.LightSlateGray;
        }

        private void buttonTabPage3_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(tabPage3);
            buttonTabpage1.BackColor = Color.LightSlateGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
            buttonTabPage3.BackColor = Color.LightGray;
            buttonTabPage4.BackColor = Color.LightSlateGray;
            buttonTabPage5.BackColor = Color.LightSlateGray;
            buttonTabPage6.BackColor = Color.LightSlateGray;
        }

        private void buttonTabPage4_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(tabPage4);
            buttonTabpage1.BackColor = Color.LightSlateGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
            buttonTabPage3.BackColor = Color.LightSlateGray;
            buttonTabPage4.BackColor = Color.LightGray;
            buttonTabPage5.BackColor = Color.LightSlateGray;
            buttonTabPage6.BackColor = Color.LightSlateGray;
        }

        private void buttonTabPage5_Click(object sender, EventArgs e)
        {
            Tab.SelectTab(tabPage5);
            buttonTabpage1.BackColor = Color.LightSlateGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
            buttonTabPage3.BackColor = Color.LightSlateGray;
            buttonTabPage4.BackColor = Color.LightSlateGray;
            buttonTabPage5.BackColor = Color.LightGray;
            buttonTabPage6.BackColor = Color.LightSlateGray;
        }

        private void buttonTabPage6_Click(object sender, EventArgs e)
        {

            Tab.SelectTab(tabPage6);
            buttonTabpage1.BackColor = Color.LightSlateGray;
            buttonTabPage2.BackColor = Color.LightSlateGray;
            buttonTabPage3.BackColor = Color.LightSlateGray;
            buttonTabPage4.BackColor = Color.LightSlateGray;
            buttonTabPage5.BackColor = Color.LightSlateGray;
            buttonTabPage6.BackColor = Color.LightGray;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (button8.BackColor == Color.DarkSlateGray)
            {
                button8.BackColor = Color.Transparent;
                this.TopMost = false;

            }

            else if (button8.BackColor == Color.Transparent)
            {
                this.TopMost = true;
                button8.BackColor = Color.DarkSlateGray;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Exit This?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (IsExsist() == true)
            {
                Tab.SelectTab(tabPage2);
                buttonTabpage1.BackColor = Color.LightGray;
                buttonTabpage1.Enabled = true;
                buttonTabPage2.Enabled = true;
                buttonTabPage3.Enabled = true;
                buttonTabPage4.Enabled = true;
                buttonTabPage5.Enabled = true;
                buttonTabPage6.Enabled = true;
            }

            else
            {
                MessageBox.Show("Wrong Password OR User");
            }

        }

        bool IsExsist()
        {
            bool isok = false;
           
                if (textBox2.Text =="admin"&& Convert.ToInt32 (textBox1.Text) == 12345)
                {

                    isok = true;
                }


            return isok;
        }

        private void dataGridViewStockIn_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                stockIntextBox.Text = dataGridViewStockIn.Rows[e.RowIndex].Cells[2].Value.ToString();
                stockIn.StockInID = Convert.ToInt32(dataGridViewStockIn.Rows[e.RowIndex].Cells[0].Value);

                buttonStockIn.Text = "Edit";
            }


            catch (Exception exp)
            {

                MessageBox.Show(exp.Message);
            }
        }

        

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {

            if (M == 1)
            {
                this.SetDesktopLocation(MousePosition.X - X, MousePosition.Y - Y);
            }

        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            M = 0;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {

            M = 1;
            X = e.X;
            Y = e.Y;
        }
    }
}

