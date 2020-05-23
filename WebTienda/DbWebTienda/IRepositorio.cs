using System.Collections.Generic;

namespace DbWebTienda
{
    public interface IRepositorio
    {
        List<PRODUCTO> GetProductos();
        List<TIENDA> GetTipoTienda();
        Respuesta GuardarProducto(PRODUCTO Producto);
        Respuesta EliminarProducto(int sku);
        List<PRODUCTO> ObtenerProductosId(int IdTienda);
    }
}