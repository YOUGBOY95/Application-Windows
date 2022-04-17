using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_windows
{
    public partial class dashbord2 : Form
    {
        public dashbord2()
        {
            InitializeComponent();
        }

        private void dashbord2_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'usersDataSet1.Table_users'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.table_usersTableAdapter.Fill(this.usersDataSet1.Table_users);

        }

        private void label10_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MovePrevious();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tableusersBindingSource.MoveNext();
        }
    }
}
