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
    
    public partial class Detalle
    {
        public int idDetalle { get; set; }
        public Nullable<int> idPedido { get; set; }
        public string nombreConsumo { get; set; }
        public string estado { get; set; }
        public Nullable<int> costo { get; set; }
    
        public virtual Pedido Pedido { get; set; }
    }
}
