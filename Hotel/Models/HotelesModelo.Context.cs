﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hoteles.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class hotelesEntidad : DbContext
    {
        public hotelesEntidad()
            : base("name=hotelesEntidad")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<habitacion> habitacion { get; set; }
        public virtual DbSet<reserva> reserva { get; set; }
        public virtual DbSet<hotel> hotel { get; set; }
    }
}
