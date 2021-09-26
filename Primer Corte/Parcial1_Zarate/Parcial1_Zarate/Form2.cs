using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_Zarate
{
    public partial class Form2 : Form
    {
        private Form formularioPrincipal;
        public Form2( Form formularioPrincipal )
        {
            InitializeComponent();
            this.formularioPrincipal = formularioPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formularioPrincipal.Show();
            this.Close();
        }
    }
}
