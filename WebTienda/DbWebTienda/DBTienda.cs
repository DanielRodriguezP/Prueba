namespace DbWebTienda
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBTienda : DbContext
    {
        public DBTienda()
            : base("name=DBTienda")
        {
        }

        public virtual DbSet<PRODUCTO> PRODUCTO { get; set; }
        public virtual DbSet<TIENDA> TIENDA { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCTO>()
                .Property(e => e.DESCRIPCION)
                .IsUnicode(false);

            modelBuilder.Entity<TIENDA>()
                .Property(e => e.NOMBRE)
                .IsUnicode(false);

            modelBuilder.Entity<TIENDA>()
                .HasMany(e => e.PRODUCTO)
                .WithRequired(e => e.TIENDA1)
                .HasForeignKey(e => e.TIENDA)
                .WillCascadeOnDelete(false);
        }
    }
}
