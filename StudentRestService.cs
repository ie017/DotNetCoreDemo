using Microsoft.AspNetCore.Mvc;
using DotNetCoreDemo;
using DotNetCoreDemo.Model.Librarys;
using DotNetCoreDemo.Model.Students;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreDemo{
    [Route("/api/students")]
    [ApiController]
    public class StudentRestService:ControllerBase{
        private LibraryDbRepository libraryDbRepository;
        public StudentRestService(LibraryDbRepository libraryDb){
            libraryDbRepository = libraryDb;
        }
        [HttpGet]
        public IEnumerable<Student> list(){
            return libraryDbRepository.students.Include(s=>s.library); // retourne la liste des etudiants
        }

        [HttpGet("{id}")]
        public Student getOne(long id){
            return libraryDbRepository.students.Include(s=>s.library).FirstOrDefault(s => s.Id == id)!;
        }

        [HttpPost]
        public Student save([FromBody] Student student){
            libraryDbRepository.students.Add(student); // il faut validé l'operation ey pour cela on fait l'appel à SaveChanges
            libraryDbRepository.SaveChanges();
            return student;
        }

        [HttpDelete("{id}")]
        public void delete(long id){
            Student student = libraryDbRepository.students.FirstOrDefault(s=>s.Id == id)!;
            libraryDbRepository.students.Remove(student);
            libraryDbRepository.SaveChanges();
        }

        [HttpPut("{id}")]
        public Student update(long id, [FromBody] Student student){
            student.Id = id;
            libraryDbRepository.students.Update(student);
            libraryDbRepository.SaveChanges();
            return student;
        }
    }
}