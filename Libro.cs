using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTuLibro
{
    public class Libro
    {
        private string _imagePath; // Ruta de la imagen de portada
        private string _titulo; // Título del libro
        private List<VentaLibro> _ventaslibro; // Lista de vendedores que venden este libro

        public Libro(string imagePath, string titulo)
        {
            _imagePath = imagePath;
            _titulo = titulo;
            _ventaslibro = new List<VentaLibro>();
        }

        public string ImagePath
        {
            get => _imagePath;
            set => _imagePath = value;
        }

        public string Titulo
        {
            get => _titulo;
            set => _titulo = value;
        }

        public List<VentaLibro> VentaLibros
        {
            get => _ventaslibro;
            set => _ventaslibro = value;
        }
    }
}
