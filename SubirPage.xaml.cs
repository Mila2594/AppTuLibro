using System.Diagnostics;

namespace AppTuLibro;

public partial class SubirPage : ContentPage
{
    private VendedoresStorage _vendedoresStorage;
    private bool _librosEnVentaVisible = false;
    private BibliotecaService _bibliotecaService;



    public SubirPage()
	{
        InitializeComponent();
        _vendedoresStorage = new VendedoresStorage();
        _bibliotecaService = BibliotecaService.Instance; // Acceso al servicio

    }

	//comportamiento de boton Crear Cuenta en el FrameInicial
	private void OnFrameCrearCuentaClicked (object sender, EventArgs e)
	{
        frameInicial.IsVisible = false;
        frameCrearCuenta.IsVisible = true;
    }

	//comportamiento de botón Iniciar sesión el FrameInical
	private void OnFrameLoginCuentaClicked (Object sender, EventArgs e)
	{
        frameInicial.IsVisible = false;
        frameIniciarSesion.IsVisible = true;
    }

	//comportamiento de botón Crear Cuenta en el frame Crear Cuenta
	private async void OnCreateAccountCliked (object sender, EventArgs e)
	{
		await DisplayAlert("Error", "Funcionalidad en desarrollo", "OK");
        // Volver al frame inicial
        frameInicial.IsVisible = true;
        frameCrearCuenta.IsVisible = false;
    }

	//comportamiento de botón Iniciar sesión en el frame Iniciar Sesión
	private async void OnLoginClicked(object sender, EventArgs e)
	{
        var usuarioIngresado = entryNombreIniciar.Text;
        var vendedorExistente = _vendedoresStorage.GetVendedores()
            .FirstOrDefault(v => v.Nombre.Equals(usuarioIngresado, StringComparison.OrdinalIgnoreCase));

        if (vendedorExistente != null)
        {
            // Ocultar frames y mostrar el layout principal
            frameInicial.IsVisible = false;
            frameCrearCuenta.IsVisible = false;
            frameIniciarSesion.IsVisible = false;
            layoutVendedor.IsVisible = true;
            labelVendedor.Text = $"Bienvenido, {vendedorExistente.Nombre}!";

            // Cargar los libros del vendedor
            CargarLibrosDelVendedor(vendedorExistente.Nombre);

            // Si necesitas hacer algo más con los libros o vendedores
            var todosLosLibros = _bibliotecaService.ObtenerLibros(); // Aquí obtienes todos los libro
            if (todosLosLibros != null)
            {
                Debug.WriteLine("No Hay libros");
            }
        }
        else
        {
            await DisplayAlert("Error", "Usuario no encontrado", "Ok");
        }
    }

    //comportamiento Boton "+" en opcion Libros vendidos
    private async void OnLibrosVendidosCliked(Object sender, EventArgs e)
    {
        await DisplayAlert("Lo sentimos", "Funcionalidad en desarrollo", "Ok");
    }

    //comportamiento Boton "+" en opcion Libros en venta
    private void OnLibrosEnVentaClicked(object sender, EventArgs e)
    {
        _librosEnVentaVisible = !_librosEnVentaVisible;
        btnLibrosEnVenta.Text = _librosEnVentaVisible ? "-" : "+";

        // Actualiza la visibilidad de la lista de libros
        listViewLibrosEnVenta.IsVisible = _librosEnVentaVisible;
    }

    //método para cargar lista de libros segun el usuario ingresado
    private void CargarLibrosDelVendedor(string nombreVendedor)
    {
        // Obtener el vendedor por nombre
        var vendedor = _vendedoresStorage.GetVendedores()
            .FirstOrDefault(v => v.Nombre.Equals(nombreVendedor, StringComparison.OrdinalIgnoreCase));

        if (vendedor != null)
        {
            // Obtener los libros del vendedor usando el nuevo método
            var librosDelVendedor = _vendedoresStorage.ObtenerLibrosPorVendedor(vendedor.Nombre);

            Debug.WriteLine($"Libros del vendedor: {string.Join(", ", librosDelVendedor)}"); // Debug

            if (librosDelVendedor.Any())
            {
                listViewLibrosEnVenta.IsVisible = true;
                listViewLibrosEnVenta.ItemsSource = librosDelVendedor.Select(titulo => new { Title = titulo }).ToList();
            }
            else
            {
                listViewLibrosEnVenta.ItemsSource = null;
                listViewLibrosEnVenta.IsVisible = false;
                Debug.WriteLine("No hay libros en la lista del vendedor.");
            }
        }
        else
        {
            listViewLibrosEnVenta.ItemsSource = null;
            listViewLibrosEnVenta.IsVisible = false;
            Debug.WriteLine("No se encontró al vendedor.");
        }
    }
}