//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccountingAPZ.DataFiles
{
    using System;
    using System.Collections.Generic;
    
    public partial class MaterialProducts
    {
        public int MaterialId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> CountMat { get; set; }
    
        public virtual Materials Materials { get; set; }
        public virtual Products Products { get; set; }
    }
}
