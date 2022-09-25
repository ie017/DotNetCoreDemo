using Microsoft.AspNetCore.Mvc;
using DotNetCoreDemo;
using DotNetCoreDemo.Model.Librarys;
using DotNetCoreDemo.Model.Books;
using DotNetCoreDemo.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreDemo{
    [Route("/api/libraries")]
    [ApiController]
    public class LibraryRestService:ControllerBase{
        private LibraryDbRepository libraryDbRepository;
        public LibraryRestService(LibraryDbRepository libraryDb){
            libraryDbRepository = libraryDb;
        }
        [HttpGet]
        public IEnumerable<Library> list(){
            return libraryDbRepository.libraries; // retourne la liste des etudiants
        }

        [HttpGet("{id}")]
        public Library getOne(long id){
            return libraryDbRepository.libraries.FirstOrDefault(l => l.LibraryId == id)!;
        }

        [HttpPost]
        public Library save([FromBody] Library library){
            libraryDbRepository.libraries.Add(library); // il faut validé l'operation ey pour cela on fait l'appel à SaveChanges
            libraryDbRepository.SaveChanges();
            return library;
        }

        [HttpDelete("{id}")]
        public void delete(long id){
            Library library = libraryDbRepository.libraries.FirstOrDefault(l=>l.LibraryId == id)!;
            libraryDbRepository.libraries.Remove(library);
            libraryDbRepository.SaveChanges();
        }

        [HttpPut("{id}")]
        public Library update(long id, [FromBody] Library library){
            library.LibraryId = id;
            libraryDbRepository.libraries.Update(library);
            libraryDbRepository.SaveChanges();
            return library;
        }
        [HttpGet("{id}/books")] // pour retourner tout les livres d'un library spécifié
        public ICollection<Book> getAllBooks(long id){
            Library library = libraryDbRepository.libraries.Include(b=>b.books).FirstOrDefault(l => l.LibraryId == id)!;
            return library.books!;
            
        }
        [HttpGet("{id}/students")] // pour retourner tout les etudiants d'un library spécifié
        public ICollection<Student> getAllStudents(long id){
            Library library = libraryDbRepository.libraries.Include(b=>b.Students).FirstOrDefault(l => l.LibraryId == id)!;
            return library.Students!;
            
        }
    }
}