using System.Threading.Tasks;

namespace EFIntro
{
    partial class Program
    {
        static void WriteToDB(AddressBookContext db) 
        {
            db.Persons.AddRange(new [] {
                new Person() { FirstName = "Tom", LastName = "Turbo" },
                new Person() { FirstName = "Foo", LastName = "Bar" }
            });
            db.SaveChangesAsync();
        }
    }
}
