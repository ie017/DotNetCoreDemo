using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using DotNetCoreDemo.Model.Books;
using DotNetCoreDemo.Model.Students;
using System.Text.Json.Serialization;

namespace DotNetCoreDemo.Model.Librarys{
    [Table("libraries")]
    public class Library{
        public long LibraryId {get; set;}
        public string? Name {get; set;}
        public string? Address {get; set;}
        [JsonIgnore] // pour eviter le bouclage
        public virtual ICollection<Book>? books {get; set;}
        [JsonIgnore] // pour eviter le bouclage
        public virtual ICollection<Student>? Students {get; set;}
        

    }
}