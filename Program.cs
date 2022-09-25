using Microsoft.EntityFrameworkCore;
using DotNetCoreDemo.Model.Librarys;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
//builder.Services.AddControllersWithViews(); // Ajouter le service ControllersWithViews 
// AddDbContext comme moyen de configurer l'accès à la base de données et d'agir comme une unité de travail
builder.Services.AddDbContext<LibraryDbRepository>(
    options => {options.UseInMemoryDatabase("Generatelibraries");} // Configures the context to connect to a named in-memory database
);
var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//app.UseStaticFiles(); // pour pouvoir accéder aux fichiers statiques js, css, html
//app.UseRouting();

app.MapControllerRoute( /* Cette Configuration de route permet de travailler avec les Controllers & Views*/
    name: "default",
    pattern: "{controller}/{action}/{id?}" /*{id} pour dire on peut ajouter les parameters et avec ? 
    pour indique que ce parametre n'est obligatoir */
);

//app.MapGet("/", () => "Hello ie017!");
//app.UseHttpsRedirection(); // pour rediriger la requete vers le port 7020
//app.UseAuthorization();
app.MapControllers();
app.Run();
