using System.Drawing;
using HelloEF.DomainModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace HelloEF.ChangeTrackerExample {
    public static class Example {

        /// <summary>
        /// This method shows a little bit deeper on how EF distiguishes an Insert from an Update or Delete
        /// </summary>
        public static async Task EntityStates(SchoolContext dbContext)
        {
            var department = new Department() { Name="My Test Department" };

            //.Entry gets information of a certain entity, inside the ChangeTracker mechanism of EF
            //ChangeTracker, is a mechanism that EF Core uses on models, before translating model actions in sql query.
            //Everything that happens here, is in-memory.
            var state = dbContext.Entry(department).State; //<< Detached

            dbContext.Departments.Add(department);
            state = dbContext.Entry(department).State; //<< Added

            await dbContext.SaveChangesAsync();
            state = dbContext.Entry(department).State; //<< Unchanged (means, the entity in DB and ChangeTracker is the same)

            department.Name = "My updated department name";
            state = dbContext.Entry(department).State; //<< Modified

            await dbContext.SaveChangesAsync();

            dbContext.Departments.Remove(department);
            state = dbContext.Entry(department).State; //<< Deleted (does not exist in ChT)
            
            department.Name = "Demo Dept";

            state = dbContext.Entry(department).State; //<< Still deleted. Compares based on PK(id) 
            
            await dbContext.SaveChangesAsync();
            state = dbContext.Entry(department).State; //<< Detached (meaning it is in ChangeTracker, but not in DB)
        }

        public static async Task UpdateEntry(SchoolContext dbContext)
        {
            var department = new Department() { Name = "Test Brick Department"};

            dbContext.Departments.Add(department);
            //The state is Added(obviously)
            var entry1 = dbContext.Entry(department);

            //The state remains Added(because no changes are made to db from the prior query.It is still, an Added entity)
            department.Name = "Test Brick Department v2";
            var entry2 = dbContext.Entry(department);
            await dbContext.SaveChangesAsync();

            //it changes to Unchanged
            var entry3 = dbContext.Entry(department);

            //changes to Modified
            department.Name = "Test Brick Department v3";
            var entry4 = dbContext.Entry(department);

            //changes to Unchanged
            await dbContext.SaveChangesAsync();
            var entry5 = dbContext.Entry(department);

            /// the entry state is Added.The.Update(), if the PK property has no value, tracks the entry from the Added State.
            var department2 = new Department() { Name="New Department" };

            dbContext.Departments.Update(department2);

            var entry6 = dbContext.Entry(department2);
        }

        public static async Task ReadNUpdateEntry(SchoolContext dbContext)
        {
            //var departments = dbContext.Departments.ToList();

            //var untrackedDepts = dbContext.Departments.AsNoTracking().ToList();
            //var tracker =dbContext.ChangeTracker.Entries().ToList();

            var student = dbContext.Students.First();
            var tracker =dbContext.ChangeTracker.Entries().ToList();

            student.FirstName = "Demo Student 2";


            dbContext.SaveChanges();



        }

        public static async Task RawSql(SchoolContext dbContext)
        {
            //use .FromSqlRaw to return data(select) without parameters
            var students = await dbContext.Students
                .FromSqlRaw("SELECT * FROM Students")
                .ToListAsync();

            //use .FromSqlInterpolated to return data(select) with parameters
            var filter = "%z";
            students = await dbContext.Students
                .FromSqlInterpolated($"SELECT * FROM Students WHERE Name LIKE {filter}")
                .ToListAsync();

            // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD
            // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD
            // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD
            // BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD BAD
            // BAD with FromSqlRaw. Use SqlInterpolation
            //SQL INJECTION
            var badFilterInjection = "%z; DELETE FROM Students";
            students= await dbContext.Students
                .FromSqlRaw($"SELECT * FROM Students WHERE Name LIKE {badFilterInjection}")
                .ToListAsync();

            //use this(or .ExecuteFromSqlInterpolated) to perform write operations in db. Not data return, but insert/update/delete
            await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM BRICKS WHERE ID =1");
        }
        
        public static async Task Transactions(SchoolContext dbContext)
        {
            await using var transaction = await dbContext.Database.BeginTransactionAsync();
            try
            {
                dbContext.Departments.Add(new Department() { Name = "Test" });
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlRawAsync("SELECT 1/0 as Bad");
                await transaction.CommitAsync();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Something bad happened: {ex.Message}");
            }
        }

        public static async Task SqlServerTypeMapper(SchoolContext dbContext)
        {
            using (dbContext)
            {
                var sp = dbContext.GetInfrastructure<IServiceProvider>();
                var mapper = sp.GetService<IRelationalTypeMappingSource>();

                Console.WriteLine($"Type mapper in use: {mapper.GetType().Name} ");
                Console.WriteLine($"Mapping for bool: {mapper.GetMapping(typeof(bool)).StoreType}");
                Console.WriteLine($"Mapping for string: {mapper.GetMapping(typeof(string)).StoreType}");
                Console.WriteLine($"Mapping for float: {mapper.GetMapping(typeof(float)).StoreType}");
                Console.WriteLine($"Mapping for decimal: {mapper.GetMapping(typeof(decimal)).StoreType}");
            }
        }
    }
}
