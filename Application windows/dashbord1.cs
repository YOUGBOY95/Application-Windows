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
    public partial class dashbord1 : Form
    {
        public dashbord1()
        {
            InitializeComponent();
        }

        private void dashbord1_Load(object sender, EventArgs e)
        {
            
            // TODO: cette ligne de code charge les données dans la table 'usersDataSet.Table_users'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.table_usersTableAdapter.Fill(this.usersDataSet.Table_users);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.AddNew();
            MessageBox.Show("Nouvel utilisateur ajouté à la base de données.");
        }

        private void label10_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.EndEdit();
            table_usersTableAdapter.Update(usersDataSet.Table_users);
            MessageBox.Show("Votre demande à bien été enregitré.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.RemoveCurrent();
            table_usersTableAdapter.Update(usersDataSet.Table_users);
            MessageBox.Show("Vous avez bien supprimé l'utilisateur.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtboxID.Clear();
            txtboxNom.Clear();
            txtboxPrenom.Clear();
            txtboxdate.Clear();
            txtboxAdresse.Clear();
            txtboxCP.Clear();
            txtboxTel.Clear();
            txtboxNom.Focus();
            table_usersTableAdapter.Update(usersDataSet.Table_users);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MoveFirst();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MoveLast();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MovePrevious();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MoveNext();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.EndEdit();
            table_usersTableAdapter.Update(usersDataSet.Table_users);
            MessageBox.Show("Modifications effectuées avec succès.");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
