
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace CMSProject.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Product
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Product()
    {

        this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();

    }


    public int ProductID { get; set; }

    public string ProductName { get; set; }

    public string Brand { get; set; }

    public string Size { get; set; }

    public string Description { get; set; }

    public Nullable<decimal> Price { get; set; }

    public string ProductCode { get; set; }

    public Nullable<byte> Status { get; set; }

    public byte[] ImageUpload { get; set; }

    public Nullable<int> CategoryID { get; set; }

    public Nullable<System.DateTime> DateCreated { get; set; }

    public Nullable<System.DateTime> DateUpdated { get; set; }

    public string CreatedBy { get; set; }

    public string UpdateBy { get; set; }

    public string Unit { get; set; }

    public Nullable<int> Quantity { get; set; }



    public virtual Category Category { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }

}

}
