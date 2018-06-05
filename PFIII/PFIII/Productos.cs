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
        get { return producto; }
        set { producto = value; }
        }
        public double Precio
        {
        get { return precio; }
        set { precio = value; }
        }
        public int Unidades
        {
        get { return unidades; }
        set { unidades = value; }
        }
        public DateTime Fecha
        {
        get { return fecha; }
        set { fecha = value; }
        } 
    }
}
