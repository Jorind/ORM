# ORM - Entity Framework
A set of simple applications to learn ORM-EF


# Git commands

## Adding a .gitIgnore file
open git bash in any of the repo projects that you want to add the .gitIgnore file and write touch .gitIgnore
A .gitIgnore file is generated.
There we can add whatever we want to ignore. 
We can use a tool like https://www.toptal.com/developers/gitignore  to create useful .gitignore files for our proj.
Just write keywords like visualStudio, netCore, Windows ecc and c/p the generated content.
In case we haven't checked out the files we want to ignore, these are all the required steps to add a gitIgnore.
In the files are already checked out, we need to remove them from the cache first. And later on check them out again,
with the .gitIgnore file.
To do this, simply open gitbash in the proj main directory and write cmds like $ git rm -r --cached bin or $ git rm -r --cached obj or $ git rm -r --cached .vs
