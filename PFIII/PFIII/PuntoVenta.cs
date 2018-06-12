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
    List<Venta1> venta1 = new List<Venta1>();
    List<Usuarios> usuarios = new List<Usuarios>();
    int cont = 0;
    int contclientes = 0;
    string pro;
    string cli;
    string usus;
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
        cli = textBoxNit.Text;
        if(textBoxNit.Text==(clientes[i].Nit))
        {
        labelNombre.Text = clientes[i].Nombre;
        labelCiudad.Text = clientes[i].Ciudad;
        cont++;
        contclientes++;
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
        usus = Form1.usu;
        labelCajero.Text = usus;
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
        ptemp.Unidades = Convert.ToDouble(readers.ReadLine());
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
        private void button1_Click(object sender, EventArgs e)
        { 
        Productos vtemp = new Productos();
        string fileName = "Venta.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        double descontar = 0;
        for (int i = 0; i < productos.Count; i++)
        {
        pro = comboBoxProductos.Text;
        if (comboBoxProductos.Text == (productos[i].Producto))
        {
        writer.WriteLine(productos[i].Producto);
        writer.WriteLine(textBoxCantidad.Text);
        writer.WriteLine(productos[i].Precio);
        productos.Add(vtemp);
        double g =Convert.ToDouble( textBoxCantidad.Text);
        cont++;
        descontar = productos[i].Unidades-g ;
        }
        }
        if(descontar<=0)
        {
        MessageBox.Show("Unidades de producto inuficiente.");
        }
        else
        { 
        writer.Close();
        MessageBox.Show("Venta Realizada.");
        comboBoxProductos.Text = "";
        textBoxCantidad.Text = "";
        }
        } 

        private void button2_Click(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Venta.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        Productos pptemp = new Productos();
        while (reader.Peek() > -1)
        {
        pptemp.Producto = reader.ReadLine();
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        productos.Add(pptemp);
        }
        double sub = pptemp.Unidades * pptemp.Precio;
        MessageBox.Show(sub.ToString());
        reader.Close();
        }
  
        private void button3_Click(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Venta.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        Productos pptemp = new Productos();
        double total = 0;
        while (reader.Peek() > -1)
        {
        pptemp.Producto = reader.ReadLine();
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        productos.Add(pptemp);
        double sub = pptemp.Unidades * pptemp.Precio;
        total = sub+total;
        }
        MessageBox.Show(total.ToString());
        reader.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        string fileName = "Venta.txt";
        FileStream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        StreamReader reader = new StreamReader(stream);
        Productos pptemp = new Productos();
        double total = 0;
        while (reader.Peek() > -1)
        {
        pptemp.Producto = reader.ReadLine();
        pptemp.Unidades = Convert.ToDouble(reader.ReadLine());
        pptemp.Precio = Convert.ToDouble(reader.ReadLine());
        productos.Add(pptemp);
        double sub = pptemp.Unidades * pptemp.Precio;
        total = sub + total;
        }
        double efectivo = Convert.ToDouble(textBoxEfectivo.Text);
        if(efectivo>=total)
        {
        double vuelto = efectivo - total;
        labelVuelto.Text = vuelto.ToString("0.00");
        }
        else if(efectivo<total)
        {
        MessageBox.Show("DINERO INSUFICIENTE.");
        }
        reader.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
        Venta1 vetemp = new Venta1();
        Productos prtemp = new Productos();
        string fileName = "Factura.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        for (int i = 0; i < productos.Count; i++)
        {
        if ((cont >= 1) && (pro == productos[i].Producto))
        {
        writer.WriteLine("Producto: "+productos[i].Producto);
        writer.WriteLine("Unidades: "+productos[i].Unidades);
        writer.WriteLine("Fecha: " + productos[i].Fecha);
        vetemp.Producto = productos[i].Producto;
        vetemp.Unidades = productos[i].Unidades;
        vetemp.Fh = productos[i].Fecha;
        venta1.Add(vetemp);
        }
        }
        for (int j = 0; j < clientes.Count;j++ )
        {
        if(cli==clientes[j].Nit&& contclientes==1)
        {
        writer.WriteLine("Cliente: "+clientes[j].Nombre);
        writer.WriteLine("Cajero: " + usus);
        }
        }
        writer.Close();
        MessageBox.Show("Venta Realizada.");
        }
    }
}
