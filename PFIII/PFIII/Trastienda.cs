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
    public partial class Trastienda : Form
    {
        static List<Productos> productos = new List<Productos>();
        static int posicionmodificar;
        public Trastienda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        writer.WriteLine(textBoxProductos.Text);
        writer.WriteLine(Convert.ToDouble(textBoxPrecio.Text));
        writer.WriteLine(Convert.ToInt32(textBoxUnidades.Text));
        try
        {
        writer.WriteLine(Convert.ToDateTime(textBoxFecha.Text));
        }
        catch (Exception)
        {
        MessageBox.Show("Fecha Invalida.");
        textBoxFecha.Focus();
        }
        writer.Close();
        MessageBox.Show("Datos Guardados Exitosamente.");
        textBoxProductos.Text = "";
        textBoxPrecio.Text = "";
        textBoxUnidades.Text = "";
        textBoxFecha.Text = "";
        textBoxProductos.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        string fileName = "Inventario.txt.";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos protemp = new Productos();
        protemp.Producto = reader.ReadLine();
        protemp.Precio = Convert.ToDouble(reader.ReadLine());
        protemp.Unidades = Convert.ToInt32(reader.ReadLine());
        protemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(protemp);
        }
        reader.Close();
        for (int i = 0; i < productos.Count; i++)
        {
        if (productos[i].Producto == textBoxProductos.Text)
        {
        textBoxProductos.Text = productos[i].Producto;
        textBoxPrecio.Text = productos[i].Precio.ToString();
        textBoxUnidades.Text = productos[i].Unidades.ToString();
        textBoxFecha.Text = productos[i].Fecha.ToString();
        posicionmodificar = i;
        }
        else
        {
        MessageBox.Show("Producto no encontrado.");
        textBoxProductos.Text = "";
        textBoxProductos.Focus();
        }
        }
        }

        private void Trastienda_Load(object sender, EventArgs e)
        {
        pictureBox1.Image = Image.FromFile("Mario.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
        productos[posicionmodificar].Producto = textBoxProductos.Text;
        productos[posicionmodificar].Precio = Convert.ToDouble(textBoxPrecio.Text);
        productos[posicionmodificar].Unidades = Convert.ToInt32(textBoxUnidades.Text);
        productos[posicionmodificar].Fecha = Convert.ToDateTime(textBoxFecha.Text);
        string fileNames = "Inventario.txt";
        FileStream streams = new FileStream(fileNames, FileMode.Create, FileAccess.Write);
        StreamWriter writers = new StreamWriter(streams);
        for (int i = 0; i < productos.Count; i++)
        {
        writers.WriteLine(productos[i].Producto);
        writers.WriteLine(productos[i].Precio);
        writers.WriteLine(productos[i].Unidades);
        writers.WriteLine(productos[i].Fecha);
        }
        writers.Close();
        MessageBox.Show("Datos Modificados.");
        textBoxProductos.Text = "";
        textBoxPrecio.Text = "";
        textBoxUnidades.Text = "";
        textBoxFecha.Text = "";
        textBoxProductos.Focus();
        }
    }
}
