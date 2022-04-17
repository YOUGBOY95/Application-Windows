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
    public partial class Form2 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=v2;Integrated Security=True";
        
        public Form2()
        {
            InitializeComponent();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {

            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '•';

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //permet de nettoyer une zone de texte 
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
            // quitter une application 
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection Sqlcon = new SqlConnection(connectionString))
                {
                    Sqlcon.Open();
                    string connexion = "SELECT * FROM tableV2 WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
                    SqlCommand Sqlcmd = new SqlCommand(connexion, Sqlcon);
                    SqlDataReader dr = Sqlcmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        new dashboard().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect, veuillez réessayer");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }
                }

            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}


