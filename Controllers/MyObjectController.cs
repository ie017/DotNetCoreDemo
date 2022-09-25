using Microsoft.AspNetCore.Mvc;
using DotNetCoreDemo.Model.Students;

namespace DotNetCoreDemo.Object{
    // La classe ObjectController héritée l'objet Controller
    public class MyObjectController:Controller{
        // index return la vue qui s'appele X
        
        public IActionResult index(){  // http://localhost:5148/MyObject/index => appel à index.cshtml
            IList<Student> students = new List<Student>();
            students.Add(new Student{Id=1, Name="ie017", Email="elorfissam1@gmail.com", Score=224});
            students.Add(new Student{Id=2, Name="ie018", Email="elorfissam1@gmail.com", Score=94});
            students.Add(new Student{Id=3, Name="ie017", Email="elorfissam1@gmail.com", Score=58});
            students.Add(new Student{Id=4, Name="ie017", Email="elorfissam1@gmail.com", Score=45});
            students.Add(new Student{Id=5, Name="ie017", Email="elorfissam1@gmail.com", Score=41});
            students.Add(new Student{Id=6, Name="ie017", Email="elorfissam1@gmail.com", Score=45});
            ViewBag.title = "Page template";
            //ViewData["item"] = items; // 1- pour stocker les données dans le model
            //ViewBag.items = items; // 2- Peut aussi utiliser comme ViewData pour stocker les données et le transmettez vers les views
            return View(students); // 3- le 3ème solution pour stocker items dans le model

            /* Si notre méthode retourne un objet View sans parametre ça 
        signifie qui notre view par defaut est le nome de la méthode index*/
        } 
        
        public IActionResult result(){ // http://localhost:5148/MyObject/result  MyObject: controller, result: action
            ViewBag.email = "elorfissam1@gmail.com";
            ViewBag.title = "Page template";
            ViewData["result"] = "20/30";
            return View("myresult");
        }
    }
}