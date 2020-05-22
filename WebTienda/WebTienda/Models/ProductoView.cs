using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebTienda.Models
{
    public class ProductoView
    {
        [RegularExpression("^[0-9]{1,10}$")]
        public int SKU{get; set;}
        [RegularExpression("^[a-zA-Z]{20}$")]
        public string NOMBRE{get; set;}
        [RegularExpression("^[a-zA-Z]{30}$")]
        public string DESCRIPCION{get; set;}
        [RegularExpression("^[0-9]{10}")]
        public int VALOR{get; set;}
        [RegularExpression("^[0-9]{1,10}")]
        public int IdTienda { get; set; }
        [RegularExpression("^[A-Za-z]{1,25}")]
        public string NOMBRE_TIENDA { get; set; }
      //public byte[] IMAGEN {get; set;}
    }
}