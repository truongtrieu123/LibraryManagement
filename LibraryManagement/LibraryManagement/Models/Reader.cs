//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryManagement.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reader()
        {
            this.BookRentalHitory = new HashSet<BookRentalHitory>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Nullable<long> CatID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public byte[] Image { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookRentalHitory> BookRentalHitory { get; set; }
    }
}