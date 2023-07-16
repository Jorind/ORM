
# General Summary

This is the very first introduction to Entity Framework.
A very simple example written in a Console Application that quickly shows
all the steps and configurations required for EF to be used.

# Steps
Entity Framework has to be globally installed in the local environment.

And then, we install the Package Dependencies from Nuget Packages.
This example only installs .Design and .InMemory packages.
It uses an InMemory database (keeping this example as simple as it can be).

After that, we create a Context class, inheriting the DbContext class
and there we can define all the configuration options, all the class-table relations
and define all the classes that should be translated into tables.

And lastly, we can create instances/objects from our Custom Context class
and write simple queries to write to and read from a database.

# Final thought
Please, take a moment to review the files generated and how they work.
