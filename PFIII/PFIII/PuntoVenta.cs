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
    List<Productos> productos = new List<Productos>();
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
        int cont=0;
        for (int i = 0; i < clientes.Count; i++)
        {
        if(textBoxNit.Text==(clientes[i].Nit))
        {
        labelNombre.Text = clientes[i].Nombre;
        labelCiudad.Text = clientes[i].Ciudad;
        cont++;
        }
        }
        if(cont==0)
        {
        MessageBox.Show("NO EXISTEN DATOS.");
        label12.Show();
        label13.Show();
        textBoxNombre.Show();
        textBoxCiudad.Show();
        button7.Show();
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
        //ComboBox
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        string fileNames = "Inventario.txt";
        FileStream streams = new FileStream(fileNames, FileMode.Open, FileAccess.Read);
        StreamReader readers = new StreamReader(streams);
        while (readers.Peek() > -1)
        {
        Productos ptemp = new Productos();
        ptemp.Producto = readers.ReadLine();
        ptemp.Precio = Convert.ToDouble(readers.ReadLine());
        ptemp.Unidades = Convert.ToInt32(readers.ReadLine());
        ptemp.Fecha = Convert.ToDateTime(readers.ReadLine());
        productos.Add(ptemp);
        }
        for (int i = 0; i < productos.Count; i++)
        {
        comboBoxProductos.Items.Add(productos[i].Producto);
        }
        readers.Close();
        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        string fileName = "Clientes.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        writer.WriteLine(textBoxNit.Text);
        writer.WriteLine(textBoxNombre.Text);
        writer.WriteLine(textBoxCiudad.Text);
        writer.Close();
        MessageBox.Show("Datos Guardados Exitosamente.");
        textBoxNit.Text = "";
        textBoxNombre.Text = "";
        textBoxCiudad.Text = "";
        textBoxNit.Focus();
        for (int i = 0; i < clientes.Count; i++)
        {
        if(textBoxNit.Text==(clientes[i].Nit))
        {
        labelNombre.Text = clientes[i].Nombre;
        labelCiudad.Text = clientes[i].Ciudad;
        }
        } 
        }
    }
}
