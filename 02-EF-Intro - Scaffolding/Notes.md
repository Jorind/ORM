

# General Summary

This is a very simple demostration of Database-First approach using Entity Framework.
We have an existing database and we would like to manage it from the code now on, using EF.
By using only one command we get a perfect view and understanding of what classes EF generates, 
how they re related and most importantly, we learn the template of files we need to create
on our own later on, so that we can start using Code First Approach.

# Steps
Only execute the following command according to the description below...

To scaffold a db, you have to run the following command in a Package Manager Console.
View -> OtherWindows -> Package Manager Console
```bash
Scaffold-DbContext "Server=.;Database=Dishes;Trusted_Connection=1;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DishContext
```

!!! As explained above, we have to have an existing database and scaffold that one.
You can either replace the naming with your own database, or make use of the Dishes database that i have also attached to this project
as a back up. (Search online how to restore the .bak file).

# Final thought
Please, take a moment to review the files generated and how they work.
