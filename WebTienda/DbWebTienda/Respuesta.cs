using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DbWebTienda
{
    public class Respuesta
    {
        public int Id { get; set; }
        public string Mensaje { get; set; }
        public bool Succes { get; set; }
    }
}