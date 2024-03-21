using Example.Models;

namespace Example.Data
{
    public static class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext db)
        {
            // Delete the database before we initialize it. This is common to do during development.
            db.Database.EnsureDeleted();

            // Recreate the database and tables according to our models
            db.Database.EnsureCreated();

            // Add test data to simplify debugging and testing

            var authors = new[]
            {
                new Author("Author 1", "Author 1", new DateTime(1981, 1, 1)),
                new Author("Author 2", "Author 2", new DateTime(1982, 2, 2)),
                new Author("Author 3", "Author 3", new DateTime(1983, 3, 3))
            };
            
            db.Authors.AddRange(authors);

            // Finally save the added relationships
            db.SaveChanges();
        }
    }
}
