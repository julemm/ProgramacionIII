using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PFIII
{
    public partial class PuntoVenta : Form
    {
    List<Clientes> clientes = new List<Clientes>();
        public PuntoVenta()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        Clientes clientestemp = new Clientes();
        string fileName = "Clientes.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        for (int i = 0; i < clientes.Count; i++)
        {
        if(textBoxNit.Text==(clientes[i].Nit))
        {
        labelNombre.Text = clientes[i].Nombre;
        labelCiudad.Text = clientes[i].Ciudad;
        }
        else if(textBoxNit.Text!=clientes[i].Nit)
        {
        label12.Show();
        label13.Show();
        textBoxNombre.Show();
        textBoxCiudad.Show();
        }
        } 
        writer.Close();
        textBoxNit.Text="";
        }

        private void PuntoVenta_Load(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Clientes.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Clientes clientestemp = new Clientes();
        clientestemp.Nit = reader.ReadLine();
        clientestemp.Nombre = (reader.ReadLine());
        clientestemp.Ciudad=reader.ReadLine();
        clientes.Add(clientestemp);
        }
        reader.Close();
        pictureBox1.Image = Image.FromFile("Control.png");
        pictureBox2.Image = Image.FromFile("Pokeball.png");
        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }
    }
}
