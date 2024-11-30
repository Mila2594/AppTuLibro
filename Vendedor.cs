using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTuLibro
{
    public class Vendedor
    {
        private string _nombre; // Nombre del vendedor
        private List<string> _titulosLibros; // Lista de títulos de libros que tiene en venta

        public Vendedor(string nombre)
        {
            _nombre = nombre;
            _titulosLibros = new List<string>();
        }

        public string Nombre
        {
            get => _nombre;
            set => _nombre = value;
        }

        public List<string> TitulosLibros
        {
            get => _titulosLibros;
            set => _titulosLibros = value;
        }

        // Método para agregar un título de libro a la lista
        public void AddLibro(string titulo)
        {
            _titulosLibros.Add(titulo);
        }
    }
}
