using DbWebTienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTienda.Models;

namespace WebTienda.Controllers
{
    public class ProductoController : Controller
    {
        IRepositorio _repo;
        public ProductoController() {
            _repo = new Repositorio();
        }
        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }
        //Listar productos
        public ActionResult GetProducto() {
           
            List<PRODUCTO> _list = _repo.GetProductos();
            var result = _list.Select(x => new ProductoView {
                SKU = x.SKU,
                NOMBRE = x.NOMBRE,
                DESCRIPCION = x.DESCRIPCION,
                VALOR = x.VALOR,
                NOMBRE_TIENDA = x.TIENDA1.NOMBRE
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        //Obtener datos de la tienda
        public ActionResult GetTienda()
        {
            List<TIENDA> lista = _repo.GetTipoTienda();
            var result = lista.Select(x => new tipoTiendaView
            {
                Id = x.ID,
                Nombre = x.NOMBRE
            });
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        //Guardar producto
        public ActionResult GuardarProducto(ProductoView Producto) {
            PRODUCTO nuevoProducto = new PRODUCTO()
            {
                SKU = Producto.SKU,
                NOMBRE = Producto.NOMBRE,
                DESCRIPCION = Producto.DESCRIPCION,
                VALOR = Producto.VALOR,
                TIENDA = Producto.IdTienda
            };
            var result = _repo.GuardarProducto(nuevoProducto);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
        //Eliminar Producto
        public ActionResult EliminarProducto(int sku)
        {
            var result = _repo.EliminarProducto(sku);
            return Json(new { data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}