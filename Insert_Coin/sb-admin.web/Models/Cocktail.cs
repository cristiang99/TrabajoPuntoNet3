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
    
    public partial class Cocktail
    {
        public int idCocktail { get; set; }
        public string nombre { get; set; }
        public Nullable<int> precio_v { get; set; }
        public Nullable<int> ing1 { get; set; }
        public Nullable<int> ing2 { get; set; }
        public Nullable<int> ing3 { get; set; }
        public Nullable<int> ing4 { get; set; }
        public Nullable<int> ing5 { get; set; }
        public string descripcion { get; set; }
    }
}
