using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace DbWebTienda
{
    
    public class Repositorio : IRepositorio
    {
        private DBTienda _contex;
        public Repositorio() {
            _contex = new DBTienda();
        }
        //Obtener la lista de productos
        public List<PRODUCTO> GetProductos() {
            List<PRODUCTO> ListaProductos = _contex.PRODUCTO.ToList();
            return ListaProductos;
        }
        //Consultar por Id tienda
        public List<PRODUCTO> ObtenerProductosId(int IdTienda)
        {
            List<PRODUCTO> listaProductos = _contex.PRODUCTO.Where(x => x.TIENDA == IdTienda).ToList();
            return listaProductos;
        }
        //Obtiene la lista del id y nombre de las tiendas
        public List<TIENDA> GetTipoTienda() {
            List<TIENDA> _lista = _contex.TIENDA.ToList();
            return _lista;
        }

        //Guarda el producto
        public Respuesta GuardarProducto(PRODUCTO Producto) {
            Respuesta result = new Respuesta();
            try
            {
                _contex.PRODUCTO.AddOrUpdate(Producto);
                _contex.SaveChanges();
                result.Succes = true;
                result.Id = Producto.SKU;
                result.Mensaje = "Se guardo el producto exitosamente";
            }
            catch (Exception e)
            {
                result.Succes = false;
                result.Mensaje = e.Message;
            }
            return result;
        }
        //Eliminar producto
        public Respuesta EliminarProducto(int sku)
        {
            Respuesta result = new Respuesta();
            try
            {
                //LinQ = tecnologia para hacer consultas
                PRODUCTO producto = _contex.PRODUCTO.Where(x => x.SKU == sku).FirstOrDefault();
                _contex.PRODUCTO.Remove(producto);
                _contex.SaveChanges();
                result.Id = producto.SKU;
                result.Succes = true;
                result.Mensaje = "Se elimino el producto exitosamente";
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Succes = false;
            }
            return result;
        }
    }
}