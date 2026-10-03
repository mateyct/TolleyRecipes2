using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.DB;

public class RecipesDesignContextFactory : IDesignTimeDbContextFactory<RecipesContext>
{
    public RecipesContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecipesContext>();
        optionsBuilder.UseMySQL("server=localhost;user=root;database=tolleyrecipes;password=password");
        return new RecipesContext(optionsBuilder.Options);
    }
}