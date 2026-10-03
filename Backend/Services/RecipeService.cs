using Backend.DB;
using Backend.DB.Models;
using Backend.Mappers;
using Backend.Services.DataTransferObjects;
using Backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class RecipeService(RecipesContextFactory factory) : ICRUDService<Recipe>
{
    private readonly RecipesContextFactory _factory = factory;

    public async Task Create(Recipe item)
    {
        using var context = _factory.CreateDbContext();
        var result = await context.Recipes.AddAsync(item);

        await context.SaveChangesAsync();
    }

    public async Task<bool> Delete(string id)
    {
        using var context = _factory.CreateDbContext();
        var result = await context.Recipes
            .Where(r => r.Id == id)
            .ExecuteDeleteAsync();
        return result > 0;
    }

    public async Task<Recipe?> Read(string id)
    {
        using var context = _factory.CreateDbContext();
        var result = await context.Recipes
            .Where(r => r.Id == id)
            .Include(r => r.Components)
                .ThenInclude(c => c.Ingredients)
            .Include(r => r.Components)
                .ThenInclude(c => c.Instructions)
            .FirstAsync();
        foreach (var component in result.Components)
        {
            component.Instructions = [.. component.Instructions.OrderBy(i => i.Ordinal)];
        }
        return result;
    }

    public async Task Update(Recipe item)
    {
        using var context = _factory.CreateDbContext();
        var result = context.Recipes.Update(item);
        await context.SaveChangesAsync();
    }

    public async Task<ServerRecipe?> RetrieveServerRecipe(string id)
    {
        return MapRecipe.MapRecipeDbToServer(await Read(id));
    }

    /// <summary>
    /// Creates a new recipe using a ServerRecipe and a user ID, generating the format
    /// needed for it to be saved in the database.
    /// </summary>
    /// <param name="newRecipe"></param>
    /// <param name="userId"></param>
    /// <returns>The uuid of the newly created recipe.</returns>
    public async Task<string> AddNewRecipe(ServerRecipe newRecipe, string userId)
    {
        var recipe = MapRecipe.MapRecipeServerToDb(newRecipe, userId);
        await Create(recipe);
        return recipe.Id;
    }

    public bool ValidateRecipe(ServerRecipe newRecipe)
    {
        bool valid = true;
        if (newRecipe.Title.Length == 0)
        {
            newRecipe.TitleMessage = "Title is required.";
            valid = false;
        }
        if (newRecipe.PrepTime == 0)
        {
            newRecipe.PrepTimeMessage = "Prep time must be greater than 0.";
            valid = false;
        }
        if (newRecipe.CookTime == 0)
        {
            newRecipe.CookTimeMessage = "Cook time must be greater than 0.";
            valid = false;
        }
        if (newRecipe.AuthorName.Length == 0)
        {
            newRecipe.AuthorNameMessage = "Author is required";
            valid = false;
        }
        if (newRecipe.Components.Count == 0)
        {
            newRecipe.ComponentsMessage = "You must add at least one component.";
            valid = false;
        }
        int primaryCount = 0;
        foreach (var component in newRecipe.Components)
        {
            if (component.PrimaryComponent)
            {
                primaryCount++;
            }
            else if (component.Title is null || component.Title.Length == 0)
            {
                component.TitleMessage = "Non-primary components are required to have a title.";
                valid = false;
            }
            if (component.Instructions.Count == 0)
            {
                component.InstructionsMessage = "You must add at least one instruction.";
                valid = false;
            }
            foreach (var instruction in component.Instructions)
            {
                if (instruction.Instruction.Length == 0)
                {
                    instruction.InstructionMessage = "Instruction description is required.";
                    valid = false;
                }
            }
            if (component.Ingredients.Count == 0)
            {
                component.IngredientsMessage = "You must add at least one ingredient.";
                valid = false;
            }
            foreach (var ingredient in component.Ingredients)
            {
                if (ingredient.ItemName.Length == 0)
                {
                    ingredient.ItemNameMessage = "Name of the item is required.";
                    valid = false;
                }
                if (ingredient.Fraction < 0 || ingredient.Fraction == 1)
                {
                    ingredient.FractionMessage = "Fraction must be greater than 1.";
                    valid = false;
                }
            }
        }
        if (newRecipe.Components.Count > 0 && primaryCount == 0)
        {
            newRecipe.ComponentsMessage = "You must have a primary component.";
            valid = false;
        }
        else if (newRecipe.Components.Count > 0 && primaryCount > 1)
        {
            newRecipe.ComponentsMessage = "You may only have one primary component.";
            valid = false;
        }
        return valid;
    }
}
