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

        }
        public void RemoveRecipe(Recipe recipe) {

        }
        public List<Recipe> GetRecipes() {
            return recipes;
        }
        public void UpdateRecipe(Recipe oldRecipe, Recipe newRecipe) {

        }
        public void CategoriseRecipe(Recipe recipe, Categories category) {

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