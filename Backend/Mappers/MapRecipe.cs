using System;
using Backend.DB.Models;
using Backend.Services.DataTransferObjects;

namespace Backend.Mappers;

public class MapRecipe
{
    public static Recipe MapRecipeServerToDb(ServerRecipe serverRecipe, string userId)
    {
        Guid uuid = Guid.NewGuid();
        return new()
        {
            Id = uuid.ToString(),
            Title = serverRecipe.Title,
            PrepTime = serverRecipe.PrepTime,
            CookTime = serverRecipe.CookTime,
            Calories = serverRecipe.Calories,
            Servings = serverRecipe.Servings,
            AuthorName = serverRecipe.AuthorName,
            UpdatedAt = DateTime.Now,
            Rating = 0,
            RecipeCategory = serverRecipe.RecipeCategory,
            Components = [.. serverRecipe.Components.Select(MapComponentServerToDb)],
            UserId = userId,
        };
    }

    private static RecipeComponent MapComponentServerToDb(ServerRecipeComponent serverComponent)
    {
        Guid uuid = Guid.NewGuid();
        return new()
        {
            Id = uuid.ToString(),
            PrimaryComponent = serverComponent.PrimaryComponent,
            Title = serverComponent.Title,
            PrepTime = serverComponent.PrepTime,
            CookTime = serverComponent.CookTime,
            Ingredients = [.. serverComponent.Ingredients.Select(MapIngredientServerToDb)],
            Instructions = [.. serverComponent.Instructions.Select(MapInstructionServerToDb)]
        };
    }

    private static RecipeInstruction MapInstructionServerToDb(ServerRecipeInstruction serverInstruction)
    {
        Guid uuid = Guid.NewGuid();
        return new()
        {
            Id = uuid.ToString(),
            Ordinal = serverInstruction.Ordinal,
            Instruction = serverInstruction.Instruction
        };
    }

    private static Ingredient MapIngredientServerToDb(ServerIngredient serverIngredient)
    {
        Guid uuid = Guid.NewGuid();
        return new()
        {
            Id = uuid.ToString(),
            Fraction = serverIngredient.Fraction,
            MeasurementUnit = serverIngredient.MeasurementUnit,
            Quantity = serverIngredient.Quantity,
            ItemName = serverIngredient.ItemName
        };
    }

    public static ServerRecipe? MapRecipeDbToServer(Recipe? recipe)
    {
        if (recipe is null)
        {
            return null;
        }
        return new()
        {
            Id = recipe.Id,
            Title = recipe.Title,
            CookTime = recipe.CookTime,
            PrepTime = recipe.PrepTime,
            Calories = recipe.Calories,
            Servings = recipe.Servings,
            AuthorName = recipe.AuthorName,
            Rating = recipe.Rating,
            RecipeCategory = recipe.RecipeCategory,
            Components = [..recipe.Components.Select(MapComponentDbToServer)],
            UpdatedAt = recipe.UpdatedAt
        };
    }
    
    private static ServerRecipeComponent MapComponentDbToServer(RecipeComponent component)
    {
        return new()
        {
            Title = component.Title,
            PrimaryComponent = component.PrimaryComponent,
            PrepTime = component.PrepTime,
            CookTime = component.CookTime,
            Ingredients = [.. component.Ingredients.Select(MapIngredientDbToServer)],
            Instructions = [.. component.Instructions.Select(MapInstructionDbToServer)]
        };
    }

    private static ServerIngredient MapIngredientDbToServer(Ingredient ingredient)
    {
        return new()
        {
            Fraction = ingredient.Fraction,
            MeasurementUnit = ingredient.MeasurementUnit,
            Quantity = ingredient.Quantity,
            ItemName = ingredient.ItemName
        };
    }

    private static ServerRecipeInstruction MapInstructionDbToServer(RecipeInstruction instruction)
    {
        return new()
        {
            Ordinal = instruction.Ordinal,
            Instruction = instruction.Instruction
        };
    }
}
