using Microsoft.AspNetCore.Mvc;
using Example.Data;
using Example.Models;

namespace Example.Controllers;

public class AuthorsController : Controller
{
    // Added private field for the application db context
    private readonly ApplicationDbContext _db;
    
    // Constructor with db context as a parameter
    public AuthorsController(ApplicationDbContext db)
    {
        _db = db;
    }

    // GET
    public IActionResult Index()
    {
        // Fetch authors from the database
        var authors = _db.Authors.ToList();
        
        // Send the list to the view. The view declares its model as @model IEnumerable<Author> to match.
        return View(authors);
    }

    [HttpGet]
    public IActionResult Add()
    {
        // Send in an empty model to the view. Required because the view must receive a model object.
        return View(new Author());
    }
    
    [HttpPost]
    public IActionResult Add(Author author)
    {
        // Return the page with the current form values if the model is invalid. Allows the user to fix their mistakes.
        if (!ModelState.IsValid)
            return View(author);

        // Add and save the new author
        _db.Authors.Add(author);
        _db.SaveChanges();
        
        // Return back to the index view (the one with the list of authors)
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Find the existing author based on primary key
        var author = _db.Authors.Find(id);

        // Return 404 not found if the author does not exist
        if (author == null)
            return NotFound();
        
        // Reuse the add view
        return View("Add", author);
    }

    [HttpPost]
    public IActionResult Edit(int id, Author author)
    {
        // Return the page with the current form values if the model is invalid. Allows the user to fix their mistakes.
        if (!ModelState.IsValid)
            return View("Add", author);

        _db.Authors.Update(author);
        _db.SaveChanges();
        
        // Return back to the index view (the one with the list of authors)
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        // Find the existing author based on primary key
        var author = _db.Authors.Find(id);

        // Return 404 not found if the author does not exist
        if (author == null)
            return NotFound();

        _db.Authors.Remove(author);
        _db.SaveChanges();
        
        // Return back to the index view (the one with the list of authors)
        return RedirectToAction(nameof(Index));
    }
}
