using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTuLibro
{
    public class BibliotecaService
    {
        private static BibliotecaService _instance; // Instancia estática
        private List<Libro> libros = new List<Libro>();
        private List<Vendedor> vendedores = new List<Vendedor>();

        // Constructor privado para asegurar que no se pueda crear otra instancia
        private BibliotecaService() { }

        // Método para obtener la instancia de BibliotecaService
        public static BibliotecaService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BibliotecaService();
                }
                return _instance;
            }
        }

        public void AsignarVenta(Libro libro, Vendedor vendedor, int valoracion, decimal precio)
        {
            var venta = new VentaLibro(libro.Titulo, vendedor.Nombre, valoracion, precio);
            libro.VentaLibros.Add(venta);
            vendedor.TitulosLibros.Add(libro.Titulo);
        }

        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        public void AgregarVendedor(Vendedor vendedor)
        {
            vendedores.Add(vendedor);
        }

        public List<VentaLibro> ObtenerVendedoresPorLibro(Libro libro)
        {
            return libro.VentaLibros;
        }

        public List<Libro> ObtenerLibros() // Método para obtener la lista de libros
        {
            return libros;
        }
    }
}
