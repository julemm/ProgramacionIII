using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFIII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        string a = textBoxContraseña.Text;
        if ((a == "Cajeros"))
        {
        MessageBox.Show("Bienvenid@");
        PuntoVenta f2 = new PuntoVenta();
        f2.Show();
        }
        else if (a == "Trastienda")
        {
        MessageBox.Show("Bienvenid@");
        Trastienda f1 = new Trastienda();
        f1.Show();
        }
        else
        {
        MessageBox.Show("Error de autentificación");
        textBoxContraseña.Clear();
        comboBox1.Text = "";
        textBoxContraseña.Focus();
        }
        textBoxContraseña.Clear();
        comboBox1.Text = "";
        }
    }
}
