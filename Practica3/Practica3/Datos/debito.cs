//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica3.Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class debito
    {
        public int CodDebito { get; set; }
        public Nullable<int> CtaDebito { get; set; }
        public Nullable<int> Monto { get; set; }
    
        public virtual cuenta cuenta { get; set; }
    }
}
