﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sb_admin.web.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class InsertCoinDBEntities : DbContext
    {
        public InsertCoinDBEntities()
            : base("name=InsertCoinDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cocktail> Cocktail { get; set; }
        public virtual DbSet<Detalle> Detalle { get; set; }
        public virtual DbSet<Insumo> Insumo { get; set; }
        public virtual DbSet<Mesa> Mesa { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
    }
}
