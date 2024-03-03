namespace RecipeManager
{
    public class RecipeManager: IRecipe
    {
        JsonRecipeStorage jsonRecipeStorage = new JsonRecipeStorage();
        // This class is responsible for managing recipes, including saving and loading them using the JsonRecipeStorage.
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