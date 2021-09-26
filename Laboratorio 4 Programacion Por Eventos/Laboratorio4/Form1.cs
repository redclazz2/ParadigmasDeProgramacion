using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio4
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            cmbTipoDoc.Items.Add("Cedula de Ciudadania"); cmbTipoDoc.Items.Add("Tarjeta de Identidad");
            cmbTipoDoc.Items.Add("Documento de Extranjeria"); cmbTipoDoc.Items.Add("Pasaporte");
            cmbTipoDoc.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tipoDocumento = cmbTipoDoc.SelectedItem.ToString(),
                   documento = txtDocumento.Text,
                   nombre = txtNombre.Text,
                   edad = txtEdad.Text,
                   genero;

            if (rbtnMasculino.Checked == true) 
            {
                genero = "Masculino";
            }
            else 
            if(rbtnFeminino.Checked == true) 
            {
                genero = "Femenino";
            }

            MessageBox.Show(String.Format("Registro realizado correctamente, sus datos son: \n" +
                "Tipo de Documento: {0} \n" +
                "Documento: {1} \n" +
                "Nombre: {2} \n" +
                "Edad: {3} \n" +
                "Genero: {4}"
                ,tipoDocumento,documento,nombre,edad,genero));
        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))  
            {
                MessageBox.Show("Solo Numeros!");
                e.Handled = true;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                MessageBox.Show("Solo Numeros!");
                e.Handled = true;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar) && !Char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo Letras!");
            }
        }
    }
}