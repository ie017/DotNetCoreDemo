using Microsoft.AspNetCore.Mvc;
using DotNetCoreDemo;
using DotNetCoreDemo.Model.Librarys;
using DotNetCoreDemo.Model.Books;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreDemo{
    [Route("/api/books")]
    [ApiController]
    public class BookRestServices:ControllerBase{
        private LibraryDbRepository libraryDbRepository;
        public BookRestServices(LibraryDbRepository libraryDb){
            libraryDbRepository = libraryDb;
        }
        [HttpGet]
        public IEnumerable<Book> list(){
            return libraryDbRepository.books.Include(b=>b.library).Include(b=>b.Student); // retourne la liste des etudiants
            // Include pour avoir l'objet library qui liée avec LibraryId dans json book, sinon avoir null quelque soit LibraryId 
        }

        [HttpGet("{id}")]
        public Book getOne(long id){
            return libraryDbRepository.books.Include(b=>b.library).Include(b=>b.Student).FirstOrDefault(b => b.BookId == id)!;
        }

        [HttpPost]
        public Book save([FromBody] Book book){
            libraryDbRepository.books.Add(book); // il faut validé l'operation ey pour cela on fait l'appel à SaveChanges
            libraryDbRepository.SaveChanges();
            return book;
        }

        [HttpDelete("{id}")]
        public void delete(long id){
            Book book = libraryDbRepository.books.FirstOrDefault(b=>b.BookId == id)!;
            libraryDbRepository.books.Remove(book);
            libraryDbRepository.SaveChanges();
        }

        [HttpPut("{id}")]
        public Book update(long id, [FromBody] Book book){
            book.BookId = id;
            libraryDbRepository.books.Update(book);
            libraryDbRepository.SaveChanges();
            return book;
        }
        [HttpGet("search")] // exemple : http://localhost:5148/api/books/search?key=ie
        public IEnumerable<Book> search(string key){
            return libraryDbRepository.books.Include(b=>b.LibraryId).Where(b=>b.Name!.Contains(key));
        }
    }
}