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
    public partial class Form1 : Form
    {
        List<Usuarios> usuarios = new List<Usuarios>();
        public static string usu;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //Guardar
        Usuarios ustemp = new Usuarios();
        string fileName = "Entrada.txt";
        FileStream stream = new FileStream(fileName, FileMode.Append, FileAccess.Write);
        StreamWriter writer = new StreamWriter(stream);
        for (int i = 0; i < usuarios.Count; i++)
        {
        usu = comboBoxUsuario.Text;
        if (comboBoxUsuario.Text == (usuarios[i].Nombre))
        {
        writer.WriteLine(usuarios[i].Nombre);
        writer.WriteLine(usuarios[i].Departamento);
        usuarios.Add(ustemp);
        }
        }
        writer.Close();
        comboBoxUsuario.Text = "";
        //Login
        string a = textBoxContraseña.Text;
        if ((a == "Cajeros"))
        {
        MessageBox.Show("Bienvenid@");
        PuntoVenta f2 = new PuntoVenta();
        f2.Show();
        usu = comboBoxUsuario.Text;
        }
        else if (a == "Trastienda")
        {
        MessageBox.Show("Bienvenid@");
        Trastienda f1 = new Trastienda();
        f1.Show();
        usu = comboBoxUsuario.Text;
        }
        else
        {
        MessageBox.Show("Error de autentificación");
        textBoxContraseña.Clear();
        comboBoxDepartamento.Text = "";
        textBoxContraseña.Focus();
        }
        textBoxContraseña.Clear();
        comboBoxDepartamento.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        OpenFileDialog openFileDialog2 = new OpenFileDialog();
        string fileNames = "Usuarios.txt";
        FileStream streams = new FileStream(fileNames, FileMode.Open, FileAccess.Read);
        StreamReader readers = new StreamReader(streams);
        while (readers.Peek() > -1)
        {
        Usuarios utemp = new Usuarios();
        utemp.Nombre = readers.ReadLine();
        utemp.Departamento = readers.ReadLine();
        usuarios.Add(utemp);
        }
        for (int i = 0; i < usuarios.Count; i++)
        {
        comboBoxUsuario.Items.Add(usuarios[i].Nombre);
        }
        readers.Close();
        }
    }
}
