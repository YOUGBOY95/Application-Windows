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
    public partial class Form3 : Form
    {
        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=v2;Integrated Security=True";
        public Form3()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //permet de nettoyer une zone de texte 
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
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

        private void button1_Click(object sender, EventArgs e)
        {
            {
                using (SqlConnection Sqlcon = new SqlConnection(connectionString))
                {
                    Sqlcon.Open();
                    string connexion = "SELECT * FROM Table_admin WHERE username= '" + txtUsername.Text + "' and password= '" + txtPassword.Text + "'";
                    SqlCommand Sqlcmd = new SqlCommand(connexion, Sqlcon);
                    SqlDataReader dr = Sqlcmd.ExecuteReader();

                    if (dr.Read() == true)
                    {
                        new dashbord1().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Nom de l'administrateur ou mot de passe incorrect, veuillez réessayer");
                        txtUsername.Text = "";
                        txtPassword.Text = "";
                        txtUsername.Focus();
                    }
                }

            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }
    }
 }

