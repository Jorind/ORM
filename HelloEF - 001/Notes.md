
# General Notes
This is an Example of Entity Framework in a MVC Web Application.
It is a bit more complex application type because of the high number of files and folders.
But don't worry, you will learn all of them in the MVC course.
In terms of this course, the ORM, the usage is pretty much the same as in a Console Application.
The only thing that changes is the configuration of the Context class in the Program.cs, making use of the .net core advantages.
You can take a look at how our Context class is registered as a service and later on injected into controllers directly,
without the need to instantiate a new object from it every time.
Everything else stays the same.

In this example we are creating only one table, the Students table.
You can take a look at the FluentAPI configurations and also experiment a bit with the Migrations.

I have also included a students.sql script in the DefaultData folder, 
so that you can execute it directly in SQL Server after the database is created from migrations.
After this step, you can run the application, navigate to the Students Menu in UI and see a list of Students displayed there.

The Connection string is stored in appsettings.development.json (extend appsettings.json to see this file)

# Final Thought
Please, take a moment to explore the M-V-C folders and what goes into those folder.
Most importanly, review and read some more online on the Fluent API configurations and play around 
with the Migrations.