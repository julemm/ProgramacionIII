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
        List<Venta1> venta1 = new List<Venta1>();
        List<Usuarios> usuarios = new List<Usuarios>();
        static int posicionmodificar;
        string admin;
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
        writer.WriteLine(Convert.ToDouble(textBoxUnidades.Text));
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
        int cont = 0;
        while (reader.Peek() > -1)
        {
        Productos protemp = new Productos();
        protemp.Producto = reader.ReadLine();
        protemp.Precio = Convert.ToDouble(reader.ReadLine());
        protemp.Unidades = Convert.ToDouble(reader.ReadLine());
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
        cont++;
        }
        }
        if(cont==0)
        {
        MessageBox.Show("Producto no encontrado.");
        textBoxProductos.Text = "";
        textBoxProductos.Focus();
        }
        }

        private void Trastienda_Load(object sender, EventArgs e)
        {
        admin = Form1.usu;
        labelAdministrador.Text = admin;
        pictureBox1.Image = Image.FromFile("Mario.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
        productos[posicionmodificar].Producto = textBoxProductos.Text;
        productos[posicionmodificar].Precio = Convert.ToDouble(textBoxPrecio.Text);
        productos[posicionmodificar].Unidades = Convert.ToDouble(textBoxUnidades.Text);
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

        private void button3_Click(object sender, EventArgs e)
        {
        //Primera Opcion
        if ((comboBoxListas.Text == "Productos más vendidos"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos ptemp = new Productos();
        ptemp.Producto = reader.ReadLine();
        ptemp.Precio =Convert.ToDouble(reader.ReadLine());
        ptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        ptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(ptemp);
        }
        reader.Close();
        dataGridView1.DataSource = null;
        dataGridView1.Refresh();
        dataGridView1.DataSource = productos;
        dataGridView1.Refresh();
        }
        //Segunda Opcion
        if (comboBoxListas.Text == "Productos con poca existencia")
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario1.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos ptemp = new Productos();
        ptemp.Producto = reader.ReadLine();
        ptemp.Precio = Convert.ToDouble(reader.ReadLine());
        ptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        ptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(ptemp);
        }
        reader.Close();
        dataGridView1.DataSource = null;
        dataGridView1.Refresh();
        dataGridView1.DataSource = productos;
        dataGridView1.Refresh();
        }
        //Tercera Opcion
        if (comboBoxListas.Text == "Ventas cada vendedor")
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Factura.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Venta1 vtemp = new Venta1();
        vtemp.Producto = reader.ReadLine();
        vtemp.Unidades = Convert.ToDouble(reader.ReadLine());
        vtemp.Cliente = reader.ReadLine();
        vtemp.Cajero= reader.ReadLine();
        vtemp.Fh = Convert.ToDateTime(reader.ReadLine());
        venta1.Add(vtemp);
        }
        reader.Close();
        dataGridView1.DataSource = null;
        dataGridView1.Refresh();
        dataGridView1.DataSource = venta1;
        dataGridView1.Refresh();
        }
        //Cuarta Opcion
        if (comboBoxListas.Text == "Vendedor con más ventas")
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Usuarios1.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Usuarios utemp = new Usuarios();
        utemp.Nombre = reader.ReadLine();
        utemp.Departamento = reader.ReadLine();
        usuarios.Add(utemp);
        }
        reader.Close();
        dataGridView1.DataSource = null;
        dataGridView1.Refresh();
        dataGridView1.DataSource = usuarios;
        dataGridView1.Refresh();
        }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        if((comboBoxMes.Text=="Enero"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018,6,1,10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio =Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades =Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Febrero"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Marzo"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Abril"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Mayo"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Junio"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Julio"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Agosto"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Septiembre"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Octubre"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Noviembre"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        if ((comboBoxMes.Text == "Diciembre"))
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Inventario.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        while (reader.Peek() > -1)
        {
        Productos pptemp = new Productos();
        DateTime a = new DateTime(2018, 6, 1, 10, 01, 30);
        pptemp.Producto = reader.ReadLine();
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Fecha = Convert.ToDateTime(reader.ReadLine());
        productos.Add(pptemp);
        }
        reader.Close();
        dataGridView2.DataSource = null;
        dataGridView2.Refresh();
        dataGridView2.DataSource = productos;
        dataGridView2.Refresh();
        }
        }
    }
}
