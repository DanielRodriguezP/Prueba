namespace DbWebTienda
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTO")]
    public partial class PRODUCTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SKU { get; set; }

        [StringLength(20)]
        public string NOMBRE { get; set; }

        [StringLength(30)]
        public string DESCRIPCION { get; set; }

        public int VALOR { get; set; }

        public int TIENDA { get; set; }

        //[Column(TypeName = "image")]
        //[Required]
        //public byte[] IMAGEN { get; set; }

        public virtual TIENDA TIENDA1 { get; set; }
    }
}
