using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace EFIntro
{
    partial class Program
    {
        static void ReadFromDB(AddressBookContext db) 
        {
            foreach(var person in db.Persons
                .Where(p => p.LastName.StartsWith("B"))
                .AsEnumerable())
            {
                Console.WriteLine($"{person.LastName}, {person.FirstName}");
            }
        }
    }
}
