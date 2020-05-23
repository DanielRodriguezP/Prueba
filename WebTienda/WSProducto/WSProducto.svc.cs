using DbWebTienda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WebTienda.Models;

namespace WSProducto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "WSProducto" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione WSProducto.svc o WSProducto.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class WSProducto : IWSProducto
    {
        IRepositorio _repo;
        public WSProducto()
        {
            _repo = new Repositorio();
        }
        public List<PRODUCTO> obtenerProductoId(int IdTienda)
        {

            try
            {
                List<PRODUCTO> _list = _repo.ObtenerProductosId(IdTienda);
                var result = _list.Select(x => new ProductoView
                {
                    SKU = x.SKU,
                    NOMBRE = x.NOMBRE,
                    DESCRIPCION = x.DESCRIPCION,
                    VALOR = x.VALOR,
                    NOMBRE_TIENDA = x.TIENDA1.NOMBRE
                });
                return _list;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
