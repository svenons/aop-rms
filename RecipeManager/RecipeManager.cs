namespace RecipeManager
{
    public class RecipeManager: IRecipe
    {
        JsonRecipeStorage jsonRecipeStorage = new JsonRecipeStorage();
        // This class is responsible for managing recipes, including saving and loading them using the JsonRecipeStorage.
        List<Recipe> recipes = new List<Recipe>();
        public RecipeManager()
        {
            recipes = LoadRecipes();
        }
        public void AddRecipe(Recipe recipe) {
            recipes.Add(recipe);
        }
        public void RemoveRecipe(Recipe recipe) {
            if (recipes.Contains(recipe)) {
                recipes.Remove(recipe);
            }
        }
        public List<Recipe> GetRecipes() {
            return recipes;
        }
        public void UpdateRecipe(Recipe oldRecipe, Recipe newRecipe)
        {
            int index = recipes.FindIndex(r => r.Id == oldRecipe.Id);
            if (index != -1)
            {
                newRecipe.Id = oldRecipe.Id; // Keep the same ID
                recipes[index] = newRecipe;
            }
        }

        public void CategoriseRecipe(Recipe recipe, Categories category) {
            int index = recipes.FindIndex(r => r.Id == recipe.Id);
            if (index != -1)
            {
                recipes[index].Category = category;
            }
        }
        public void SaveRecipes(List<Recipe> recipes)
        {
            jsonRecipeStorage.SaveRecipes(recipes);
        }
        public List<Recipe> LoadRecipes()
        {
            return jsonRecipeStorage.LoadRecipes();
        }
    }
}