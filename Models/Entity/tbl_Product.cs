//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcStok.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Product()
        {
            this.tbl_Selling = new HashSet<tbl_Selling>();
        }
    
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Brand { get; set; }
        public Nullable<short> Product_Category { get; set; }
        public Nullable<decimal> Product_Price { get; set; }
        public Nullable<byte> Product_Stock { get; set; }
    
        public virtual tbl_Category tbl_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Selling> tbl_Selling { get; set; }
    }
}
