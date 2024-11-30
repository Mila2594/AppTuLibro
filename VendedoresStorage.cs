using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTuLibro
{
    public class VendedoresStorage
    {
        private List<Vendedor> _vendedores;
        private Dictionary<string, List<string>> _librosPorVendedor;

        public VendedoresStorage()
        {
            _vendedores = new List<Vendedor>();
            _librosPorVendedor = new Dictionary<string, List<string>>();
            InicializarVendedores();
        }

        private void InicializarVendedores()
        {
            // Inicializamos los vendedores
            _vendedores.Add(new Vendedor("estuco"));
            _vendedores.Add(new Vendedor("libtero"));
            _vendedores.Add(new Vendedor("capital"));
        }

        public List<Vendedor> GetVendedores()
        {
            return _vendedores;
        }

        // Método para asociar los títulos de libros a los vendedores
        public void AsociarLibrosAVendedores(List<VentaLibro> ventas)
        {
            foreach (var venta in ventas)
            {
                if (!_librosPorVendedor.ContainsKey(venta.NombreVendedor))
                {
                    _librosPorVendedor[venta.NombreVendedor] = new List<string>();
                }

                // Agregar el título del libro a la lista del vendedor si no está ya presente
                if (!_librosPorVendedor[venta.NombreVendedor].Contains(venta.TituloLibro))
                {
                    _librosPorVendedor[venta.NombreVendedor].Add(venta.TituloLibro);
                }
            }
        }

        // Método para obtener la lista de títulos de libros de un vendedor
        public List<string> ObtenerLibrosPorVendedor(string nombreVendedor)
        {
            if (_librosPorVendedor.TryGetValue(nombreVendedor, out var titulos))
            {
                return titulos;
            }
            return new List<string>();
        }
    }
}
