//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elbrus_region.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sotrudniki
    {
        public string code { get; set; }
        public int doljn { get; set; }
        public string FIO { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public System.DateTime vchod { get; set; }
        public int tip_vchoda { get; set; }
        public string Image1 { get; set; }
    
        public virtual Roli Roli { get; set; }
        public virtual Vchod_tip Vchod_tip { get; set; }
    }
}
