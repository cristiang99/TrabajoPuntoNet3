//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Insumo
    {
        public int idInsumo { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public Nullable<int> precio_v { get; set; }
        public Nullable<int> precio_c { get; set; }
        public Nullable<int> stock { get; set; }
        public Nullable<int> stock_min { get; set; }
        public Nullable<int> porcion { get; set; }
    }
}
