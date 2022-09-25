using DotNetCoreDemo.Model.Librarys;
using Microsoft.EntityFrameworkCore;
using DotNetCoreDemo.Model.Books;
using DotNetCoreDemo.Model.Students;

// to create ORM (Object-relational mapping)
namespace DotNetCoreDemo.Model.Librarys{
public class LibraryDbRepository : DbContext // héritage de DbContext
  {
    // Creation d'un collection de type DbSet pour gérer les libraries
    public DbSet<Library>  libraries{get; set;} = null!;

    public DbSet<Book>  books{get; set;} = null!;
    public DbSet<Student>  students{get; set;} = null!;
    // Avec base(option) on peut créer un constructeur qui fait appel a la classe parente comme super dans java
    public LibraryDbRepository(DbContextOptions<LibraryDbRepository> options):base(options){

    }
  }
}
