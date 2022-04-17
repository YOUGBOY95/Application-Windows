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

namespace Application_windows
{
    public partial class Form1 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=v2;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // quitter une application
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form2().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //permet de nettoyer une zone de texte 
            txtUsername.Clear();
            txtPassword.Clear();
            txtconfirmpwd.Clear();
            txtUsername.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Veuillez remplir les champs obligatoires");

            }
            else if (txtPassword.Text != txtconfirmpwd.Text)
                MessageBox.Show("Veuillez saisir le même mot de passe");

            else
            {
                using (SqlConnection Sqlcon = new SqlConnection(connectionString))
                {
                    Sqlcon.Open();
                    SqlCommand Sqlcmd = new SqlCommand("UserAdd", Sqlcon);
                    Sqlcmd.CommandType = CommandType.StoredProcedure;
                    Sqlcmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    Sqlcmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    Sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Vous êtes bien enregistrer.");
                    clear();
                }

            }

        }
        void clear()
        {
            txtUsername.Text = txtPassword.Text = txtconfirmpwd.Text = "";
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtconfirmpwd.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtconfirmpwd.PasswordChar = '•';
            }
        }
    }
 }


