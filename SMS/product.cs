//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
        }
    
        public int Pid { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }
        public Nullable<int> Category { get; set; }
        public Nullable<int> Brand { get; set; }
        public int Type { get; set; }
        public int Price { get; set; }
        public double Qty { get; set; }
        public System.DateTime When { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual stock stocks { get; set; }
        public virtual productbrand productbrand { get; set; }
        public virtual productcategory productcategory { get; set; }
        public virtual producttype producttype { get; set; }
    }
}
