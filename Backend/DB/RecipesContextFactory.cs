using System;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB;

public class RecipesContextFactory : IDbContextFactory<RecipesContext>
{
    public RecipesContext CreateDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<RecipesContext>();
        optionsBuilder.UseMySQL("server=localhost;user=root;database=tolleyrecipes;password=password");
        return new RecipesContext(optionsBuilder.Options);
    }
}