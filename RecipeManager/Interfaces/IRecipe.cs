namespace RecipeManager
{
    public interface IRecipe
    {
        public void AddRecipe(Recipe recipe)
        {
            // Add recipe to list
        }
        public void RemoveRecipe(Recipe recipe)
        {
            // Remove recipe from list
        }
        public List<Recipe> GetRecipes()
        {
            // Return list of recipes
            return new List<Recipe>();
        }
        public void UpdateRecipe(Recipe oldRecipe, Recipe newRecipe)
        {
            // Update recipe in list
        }
        public void CategoriseRecipe(Recipe recipe, Categories category)
        {
            // Categorise recipe
        }
        public static List<Recipe> LoadRecipes()
        {
            // Load recipes from database using IRecipeStorage
            return new List<Recipe>();
        }
        public void SaveRecipes()
        {
            // Save recipes to database using IRecipeStorage
        }
    }
}