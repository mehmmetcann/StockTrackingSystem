using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockTrackingSystem
{
    public partial class FrmCategory : Form
    {
        string connectionString = @"Server=localhost\SQLEXPRESS;Database=StockDb;Trusted_Connection=True;";

        void CategoryList()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("SELECT CategoryId, CategoryName FROM Categories", connection);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewCategories.DataSource = dt;
        }

        public FrmCategory()
        {
            InitializeComponent();
        }

        private void FrmCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            CategoryList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("INSERT INTO Categories (CategoryName) VALUES (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Category added successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CategoryList();
            txtCategoryName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show("Please select a category from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("UPDATE Categories SET CategoryName=@p1 WHERE CategoryId=@p2", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryName.Text);
            command.Parameters.AddWithValue("@p2", txtCategoryId.Text);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Category updated successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CategoryList();
            txtCategoryId.Clear();
            txtCategoryName.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryId.Text))
            {
                MessageBox.Show("Please select a category from the table first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this category?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
                return;

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            SqlCommand command = new SqlCommand("DELETE FROM Categories WHERE CategoryId=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtCategoryId.Text);

            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Category deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CategoryList();
            txtCategoryId.Clear();
            txtCategoryName.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                CategoryList();
                return;
            }

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT CategoryId, CategoryName FROM Categories WHERE CategoryName LIKE '%' + @p1 + '%'",
                connection
            );

            da.SelectCommand.Parameters.AddWithValue("@p1", txtSearch.Text);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewCategories.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void dataGridViewCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRow = dataGridViewCategories.SelectedCells[0].RowIndex;

            txtCategoryId.Text = dataGridViewCategories.Rows[selectedRow].Cells[0].Value.ToString();
            txtCategoryName.Text = dataGridViewCategories.Rows[selectedRow].Cells[1].Value.ToString();
        }

    }
}