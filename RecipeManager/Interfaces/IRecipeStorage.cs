namespace RecipeManager
{
    public interface IRecipeStorage
    {
        public static void SaveRecipes(List<Recipe> recipes)
        {
            // Save recipes to database
        }
        public static List<Recipe> LoadRecipes()
        {
            // Load recipes from database
            return new List<Recipe>();
        }   
    }
}