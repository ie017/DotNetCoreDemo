using DotNetCoreDemo.Model.Librarys;
using DotNetCoreDemo.Model.Students;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreDemo.Model.Books{
    [Table("Books")]
    public class Book{
        public long BookId{get; set;}
        public string? Name{get; set;}
        public double price{get; set;}
        public long LibraryId{get; set;}
        [ForeignKey("LibraryId")]
        public virtual Library? library{get; set;} // virtual pour travailler avec mode lazy

        public long StudentId{get; set;}
        [ForeignKey("StudentId")]
        public virtual Student? Student{get; set;}

    }
}