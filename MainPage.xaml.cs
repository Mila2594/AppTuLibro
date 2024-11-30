using System.Globalization;

namespace AppTuLibro
{
    public partial class MainPage : ContentPage
    {
        private BibliotecaService _bibliotecaService;
        private List<Libro> _libros;
        private VendedoresStorage _vendedoresStorage;
        private readonly List<string> _portadas;
        private List<VentaLibro> _ventas;
        private int libroActualIndex = 0;

        public MainPage()
        {
            InitializeComponent();
            _bibliotecaService = BibliotecaService.Instance; // Usamos el singleton
            _libros = _bibliotecaService.ObtenerLibros(); // Obtenemos la lista de libros del singleton
            _portadas = new List<string>();
            _vendedoresStorage = new VendedoresStorage();
            _ventas = new List<VentaLibro>();
            InicializarDatos();
            ActualizarVista();
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            if (libroActualIndex == 0)
            {
                libroActualIndex = _libros.Count - 1;
            }
            else
            {
                libroActualIndex--;
            }
            ActualizarVista();
        }

        private void OnNextCliked(object sender, EventArgs e)
        {
            if (libroActualIndex == _libros.Count - 1)
            {
                libroActualIndex = 0;
            }
            else
            {
                libroActualIndex++;
            }
            ActualizarVista();
        }

        private void ActualizarVista()
        {
            var libroActual = _libros[libroActualIndex];
            displayedImage.Source = libroActual.ImagePath;
            BookTitle.Text = libroActual.Titulo;
            ActualizarVendedores(libroActual.Titulo);
        }

        private void ActualizarVendedores(string tituloLibro)
        {
            var vendedoresFiltrados = _ventas
                .Where(v => v.TituloLibro == tituloLibro)
                .Select(v => new
                {
                    SellerName = v.NombreVendedor,
                    StarRating = ObtenerValoracionEstrellas(v.Valoracion),
                    Price = v.Precio.ToString("C", new CultureInfo("es-Es"))
                })
                .ToList();

            CollectionView.ItemsSource = vendedoresFiltrados;
        }

        private void InicializarDatos()
        {
            // Si deseas agregar libros directamente al singleton en lugar de a la lista local:
            var libro1 = new Libro("don_quijote_de_la_mancha.png", "Don Quitoje de La Mancha");
            var libro2 = new Libro("cien_anyos_de_soledad.png", "Cien años de soledad");
            var libro3 = new Libro("anna_karenina.jpg", "Anna Karénina");
            var libro4 = new Libro("el_alquimista.jpg", "El Alquimista");
            var libro5 = new Libro("los_funerales_de_la_mama_grande.png", "Los funerales de la Mamá Grande");

            _bibliotecaService.AgregarLibro(libro1);
            _bibliotecaService.AgregarLibro(libro2);
            _bibliotecaService.AgregarLibro(libro3);
            _bibliotecaService.AgregarLibro(libro4);
            _bibliotecaService.AgregarLibro(libro5);

            // Inicializar ventas
            InicializarVentasLibros();
        }

        private void InicializarVentasLibros()
        {
            var vendedores = _vendedoresStorage.GetVendedores();

            _ventas.Add(new VentaLibro(_libros[0].Titulo, vendedores[1].Nombre, 4, 12.50m));
            _ventas.Add(new VentaLibro(_libros[0].Titulo, vendedores[2].Nombre, 5, 18.00m));
            _ventas.Add(new VentaLibro(_libros[1].Titulo, vendedores[0].Nombre, 3, 15.50m));
            _ventas.Add(new VentaLibro(_libros[1].Titulo, vendedores[1].Nombre, 5, 20.00m));
            _ventas.Add(new VentaLibro(_libros[1].Titulo, vendedores[2].Nombre, 3, 17.50m));
            _ventas.Add(new VentaLibro(_libros[2].Titulo, vendedores[2].Nombre, 4, 12.50m));
            _ventas.Add(new VentaLibro(_libros[3].Titulo, vendedores[0].Nombre, 4, 19.50m));
            _ventas.Add(new VentaLibro(_libros[3].Titulo, vendedores[2].Nombre, 3, 11.50m));
            _ventas.Add(new VentaLibro(_libros[4].Titulo, vendedores[0].Nombre, 2, 12.50m));
            _ventas.Add(new VentaLibro(_libros[4].Titulo, vendedores[1].Nombre, 4, 17.50m));
            _ventas.Add(new VentaLibro(_libros[4].Titulo, vendedores[2].Nombre, 3, 10.00m));

            _vendedoresStorage.AsociarLibrosAVendedores(_ventas);
        }

        private string ObtenerValoracionEstrellas(int valoracion)
        {
            const int maxEstrellas = 5;
            var estrellasRellenas = new string('★', valoracion);
            var estrellasVacias = new string('☆', maxEstrellas - valoracion);
            return estrellasRellenas + estrellasVacias;
        }
    }

}
