//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sales
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public double Cost { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
        public int GoodsId { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Manager Manager { get; set; }
        public virtual Goods Goods { get; set; }
    }
}
