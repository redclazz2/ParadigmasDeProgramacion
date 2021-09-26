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
    public partial class Form1 : Form
    {
        public void cargarFormulario(string tipoUsuario) 
        {
            Form formCarga;
            if(tipoUsuario == "Admin") { formCarga = new Form2(this); }
            else { formCarga = new Form3(this); }

            this.Hide();
            formCarga.Show();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if ((txtUsuario.Text == "admin") && (txtContra.Text == "123"))
            {
                cargarFormulario("Admin");
            }
            else if (((txtUsuario.Text == "empleado") && (txtContra.Text == "321"))) 
            {
                cargarFormulario("Usuario");
            }
            else 
            {
                MessageBox.Show("Usuario o Contrasena Incorrectos ... ");
            }

        }
    }
}
