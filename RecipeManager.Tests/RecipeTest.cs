namespace RecipeManager.Tests
{
    public class RecipeTests
    {
        private Recipe _recipe;
        private List<(string, int, string)> _ingredients;
        private List<string> _instructions;

        public RecipeTests()
        {
            _ingredients = new List<(string, int, string)> { ("ingredient1", 1, "unit1") };
            _instructions = new List<string> { "instruction1" };
            _recipe = new Recipe("name", "description", _ingredients, _instructions, Categories.Breakfast);
        }

        [Fact]
        public void Constructor_AssignsCorrectValues()
        {
            Assert.Equal("name", _recipe.Name);
            Assert.Equal("description", _recipe.Description);
            Assert.Equal(_ingredients, _recipe.Ingredients);
            Assert.Equal(_instructions, _recipe.Instructions);
            Assert.Equal(Categories.Breakfast, _recipe.Category);
        }

        [Fact]
        public void Property_SettersAndGetters()
        {
            _recipe.Name = "new name";
            _recipe.Description = "new description";
            _recipe.Ingredients = new List<(string, int, string)> { ("ingredient2", 2, "unit2") };
            _recipe.Instructions = new List<string> { "instruction2" };
            _recipe.Category = Categories.Dinner;

            Assert.Equal("new name", _recipe.Name);
            Assert.Equal("new description", _recipe.Description);
            Assert.Equal(new List<(string, int, string)> { ("ingredient2", 2, "unit2") }, _recipe.Ingredients);
            Assert.Equal(new List<string> { "instruction2" }, _recipe.Instructions);
            Assert.Equal(Categories.Dinner, _recipe.Category);
        }
    }
}