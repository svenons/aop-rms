namespace RecipeManager.Tests {
    
    public class RecipeManagerTests
    {
        private Recipe _recipe;
        private List<(string, int, string)> _ingredients;
        private List<string> _instructions;
        RecipeManager _recipeManager = new RecipeManager();

        public RecipeManagerTests()
        {
            _ingredients = new List<(string, int, string)> { ("ingredient1", 1, "unit1") };
            _instructions = new List<string> { "instruction1" };
            _recipe = new Recipe("name", "description", _ingredients, _instructions, Categories.Breakfast);
        }

        [Fact]
        public void AddRecipe_AddsRecipeToManager()
        {
            _recipeManager.AddRecipe(_recipe);

            var recipes = _recipeManager.GetRecipes();

            Assert.Contains(_recipe, recipes);
        }

        [Fact]
        public void RemoveRecipe_RemovesRecipeFromManager()
        {
            _recipeManager.RemoveRecipe(_recipe);

            var recipes = _recipeManager.GetRecipes();

            Assert.DoesNotContain(_recipe, recipes);
        }

        [Fact]
        public void GetRecipes_ReturnsAddedRecipes()
        {
            _recipeManager.AddRecipe(_recipe);

            var recipes = _recipeManager.GetRecipes();

            Assert.Contains(_recipe, recipes);
        }

        [Fact]
        public void UpdateRecipe_UpdatesRecipeInManager()
        {
            Recipe _oldRecipe = _recipe;
            _recipe.Name = "new name";
            _recipeManager.UpdateRecipe(_oldRecipe, _recipe);

            var recipes = _recipeManager.GetRecipes();

            Assert.Contains(_recipe, recipes);
            Assert.Equal("new name", recipes.First(r => r.Equals(_recipe)).Name);
        }

        [Fact]
        public void CategoriseRecipe_CategorisesRecipeCorrectly()
        {
            _recipeManager.CategoriseRecipe(_recipe, Categories.Dinner);

            var recipes = _recipeManager.GetRecipes();

            Assert.Contains(_recipe, recipes);
            Assert.Equal(Categories.Dinner, recipes.First(r => r.Equals(_recipe)).Category);
        }

        [Fact]
        public void SaveAndLoadRecipes_SavesAndLoadsRecipesCorrectly()
        {
            _recipeManager.AddRecipe(_recipe);
            _recipeManager.SaveRecipes(_recipeManager.GetRecipes());

            var loadedRecipes = _recipeManager.LoadRecipes();

            Assert.Contains(_recipe, loadedRecipes);
        }
    }
}