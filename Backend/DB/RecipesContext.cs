using System;
using MySql.EntityFrameworkCore;
using Backend.DB.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DB;

public class RecipesContext(DbContextOptions<RecipesContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeComponent> RecipeComponents { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<RecipeInstruction> RecipeInstructions { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RecipeTag> RecipeTags { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
}
