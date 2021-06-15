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
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.BookRentalHitory = new HashSet<BookRentalHitory>();
        }
    
        public long ID { get; set; }
        public string Name { get; set; }
        public long CatID { get; set; }
        public string Author { get; set; }
        public Nullable<System.DateTime> PublicationDate { get; set; }
        public Nullable<System.DateTime> ImportDate { get; set; }
        public Nullable<bool> StorageState { get; set; }
        public string Location { get; set; }
        public string PublishingCompany { get; set; }
        public byte[] Image { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual StoredBook StoredBook { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookRentalHitory> BookRentalHitory { get; set; }
    }
}
