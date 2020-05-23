using System;
using DbWebTienda;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSProducto
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IWSProducto" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSProducto
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/obtenerProductoId/{IdTienda}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        List<PRODUCTO> obtenerProductoId([MessageParameter(Name = "reqobtenerProductoId")]int IdTienda);
    }
}
