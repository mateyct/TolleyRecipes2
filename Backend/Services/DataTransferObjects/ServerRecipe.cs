using System;
using Backend.Constants;

namespace Backend.Services.DataTransferObjects;

public class ServerRecipe
{
    public string? Id { get; set; }

    public string? TitleMessage { get; set; }
    public string Title { get; set; } = "";

    public string? CookTimeMessage { get; set; }
    public int CookTime { get; set; } = 0;

    public string? PrepTimeMessage { get; set; }
    public int PrepTime { get; set; } = 0;

    public int? Calories { get; set; }
    public int? Servings { get; set; }

    public string? AuthorNameMessage { get; set; }
    public string AuthorName { get; set; } = "";

    public float? Rating { get; set; }

    public Category RecipeCategory { get; set; } = Category.None;

    public string? ComponentsMessage { get; set; }
    public List<ServerRecipeComponent> Components { get; set; } = [];
    public List<string> Tags { get; set; } = [];

    public DateTime? UpdatedAt { get; set; }

    public void AddComponent()
    {
        Components.Add(new ServerRecipeComponent());
    }

    public void RemoveComponent(ServerRecipeComponent component)
    {
        Components.Remove(component);
    }

    public void ResetMessages()
    {
        TitleMessage = "";
        PrepTimeMessage = "";
        CookTimeMessage = "";
        AuthorNameMessage = "";
        ComponentsMessage = "";
        foreach (var component in Components)
        {
            component.TitleMessage = "";
            component.IngredientsMessage = "";
            foreach (var ingredient in component.Ingredients)
            {
                ingredient.ItemNameMessage = "";
            }
            component.InstructionsMessage = "";
            foreach (var instruction in component.Instructions)
            {
                instruction.InstructionMessage = "";
            }
        }
    }
}
