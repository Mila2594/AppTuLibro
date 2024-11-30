using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTuLibro
{
    public class VentaLibro
    {
        private string _tituloLibro; // Título del libro que se está vendiendo
        private string _nombreVendedor; // Nombre del vendedor que lo vende
        private int _valoracion; // Valoración del vendedor (de 1 a 5 estrellas)
        private decimal _precio; // Precio del libro

        public VentaLibro(string tituloLibro, string nombreVendedor, int valoracion, decimal precio)
        {
            _tituloLibro = tituloLibro;
            _nombreVendedor = nombreVendedor;
            _valoracion = valoracion;
            _precio = precio;
        }

        public string TituloLibro
        {
            get => _tituloLibro;
            set => _tituloLibro = value;
        }

        public string NombreVendedor
        {
            get => _nombreVendedor;
            set => _nombreVendedor = value;
        }

        public int Valoracion
        {
            get => _valoracion;
            set => _valoracion = value;
        }

        public decimal Precio
        {
            get => _precio;
            set => _precio = value;
        }
    }
}
