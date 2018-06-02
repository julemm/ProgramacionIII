using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFIII
{
    class Productos
    {
        public String producto;
        public double precio;
        public int unidades;
        DateTime fecha;
        public String Producto
        {
        get { return Producto; }
        set { Producto = value; }
        }
        public double Precio
        {
        get { return Precio; }
        set { Precio = value; }
        }
        public int Unidades
        {
        get { return Unidades; }
        set { Unidades = value; }
        }
        public DateTime Fecha
        {
        get { return Fecha; }
        set { Fecha = value; }
        } 
    }
}
