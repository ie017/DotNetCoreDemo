using Microsoft.EntityFrameworkCore;
using DotNetCoreDemo.Model.Librarys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetCoreDemo.Model.Books;
using System.Text.Json.Serialization;

namespace DotNetCoreDemo.Model.Students{
    [Table("students")] // Pour dire que les objects de type Student doit le stocker dans la table Students 
    public class Student{
        [Key]
        public long Id{get; set;}
        [Required, StringLength(10)]
        public string? Name{get; set;}
        public string? Email{get; set;}
        public int Score{get; set;}
        [JsonIgnore]
        public virtual ICollection<Book>? books{get; set;}
        public long LibraryId{get; set;}
        [ForeignKey("LibraryId")]
        public virtual Library? library{get; set;}
    }
}