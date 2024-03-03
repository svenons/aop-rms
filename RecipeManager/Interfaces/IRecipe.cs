namespace RecipeManager
{
    public interface IRecipe
    {
        public static void AddRecipe(Recipe recipe)
        {
            // Add recipe to list
        }
        public static void RemoveRecipe(Recipe recipe)
        {
            // Remove recipe from list
        }
        public static List<Recipe> GetRecipes()
        {
            // Return list of recipes
            return new List<Recipe>();
        }
        public static void UpdateRecipe(Recipe oldRecipe, Recipe newRecipe)
        {
            // Update recipe in list
        }
        public static void CategoriseRecipe(Recipe recipe, Categories category)
        {
            // Categorise recipe
        }
        public static List<Recipe> LoadRecipes()
        {
            // Load recipes from database using IRecipeStorage
            return new List<Recipe>();
        }
        public static void SaveRecipes()
        {
            // Save recipes to database using IRecipeStorage
        }
    }
}