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
    public partial class Form3 : Form
    {
        public Form formularioPrincipal;

        public Form3(Form formularioPrincipal)
        {
            InitializeComponent();
            this.formularioPrincipal = formularioPrincipal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formularioPrincipal.Show();
            this.Close();
        }

        private void txtNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras!");
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Solo Numeros!");
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int cantidadPanesAlinados = int.Parse(nmPanAlinado.Value.ToString()),
                cantidadPanesNoAlinados = int.Parse(nmPanNoAlinado.Value.ToString()),
                cantidadPanesEspeciales = int.Parse(nmEspeciales.Value.ToString()),
                totalCompra = 0;

            string nombreCliente = txtNombreCliente.Text,
                   cedula = txtCedula.Text;

            DateTime horaFecha = DateTime.Now;

            if ((nombreCliente == "" || cedula == "") || (cantidadPanesAlinados==0 && cantidadPanesNoAlinados ==0 && cantidadPanesEspeciales == 0)) 
            {
                MessageBox.Show("Error, falta introducir el nombre o la cédula del cliente o no se han " +
                    "\nespecificado panes para la compra ...");
            }
            else
            {
                totalCompra = (cantidadPanesAlinados * 1000) + (cantidadPanesNoAlinados * 500) + (cantidadPanesEspeciales * 2000);
                string facturaString = String.Format("Factura de Compra en OnlyPans: \n" +
                                "Fecha y Hora: {0} \n" +
                                "Cliente: {1} \n" +
                                "Cedula: {2} \n" +
                                "Panes Aliñados: {3} \n" +
                                "Panes No Aliñados: {4} \n" +
                                "Panes Especiales: {5} \n" +
                                "Total Compra: {6} $"
                                ,horaFecha, nombreCliente, cedula, cantidadPanesAlinados, cantidadPanesNoAlinados, cantidadPanesEspeciales, totalCompra);
                label10.Text = facturaString;
                MessageBox.Show(facturaString);

                nmPanAlinado.Value = 0;
                nmPanNoAlinado.Value = 0;
                nmEspeciales.Value = 0;

                txtNombreCliente.Text = "";
                txtCedula.Text = "";
            }
        }
    }
}
