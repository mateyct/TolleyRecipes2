using Backend.DB;
using Backend.Services;

RecipesContextFactory factory = new();

RecipeService recipeService = new(factory);

