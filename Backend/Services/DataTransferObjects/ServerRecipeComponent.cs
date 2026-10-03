namespace Backend.Services.DataTransferObjects;

public class ServerRecipeComponent
{
    public string? TitleMessage { get; set; }
    public string? Title { get; set; }
    public bool PrimaryComponent { get; set; } = false;
    public int? PrepTime { get; set; }
    public int? CookTime { get; set; }

    public string? IngredientsMessage { get; set; }
    public List<ServerIngredient> Ingredients { get; set; } = [];

    public string? InstructionsMessage { get; set; }
    public List<ServerRecipeInstruction> Instructions { get; set; } = [];

    public void AddIngredient() => Ingredients.Add(new ServerIngredient());

    public void RemoveIngredient(ServerIngredient ingredient) => Ingredients.Remove(ingredient);
    public void AddInstruction() {
        ServerRecipeInstruction instruction = new()
        {
            Ordinal = Instructions.Count
        };
        Instructions.Add(instruction);
    }

    public void RemoveInstruction(ServerRecipeInstruction instruction) => Instructions.Remove(instruction);
}
