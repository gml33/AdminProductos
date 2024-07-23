using AdminProductosNegocio;
using AdminProductosEntidades;

namespace AdminProductosFront {

    public partial class FrmAdminProductos : Form
    {
        List<Producto> productosList = new List<Producto>();
        int cantidadProductos = 0;
        public FrmAdminProductos()
        {
            InitializeComponent();
        }
        private void BuscarProductos() {

            //instancio un nuevo producto vacio y lo mando a la capa de negocios
            Producto parametro = new Producto();
            productosList = ProductosNegocio.Get(parametro);
            cantidadProductos = ProductosNegocio.Contar(productosList);
            //actualizo la grilla
            refreshGrid();
        }
        //funcion para actualizar grilla
        private void refreshGrid()
        {
            productoBindingSource.DataSource = null;
            productoBindingSource.DataSource = productosList;
            label2.Text = "-";
        }

        //cuando presiono el btn_buscar, llamo a la funcion buscar Productos
        private void btn_buscar_Click(object sender, EventArgs e)
        {
            BuscarProductos();
            label2.Text= cantidadProductos.ToString();
        }
        //cuando apreto el boton de salir, cierra el programa
        private void btn_salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
