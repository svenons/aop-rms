namespace RecipeManager
{
    public class MainMenu
    {
        // MainMenu mainMenu = new MainMenu();
        RecipeManager recipeManager = new RecipeManager();
        public MainMenu()
        {
            List<Recipe> recipes = recipeManager.LoadRecipes(); // Load recipes from the Json

            foreach (Recipe r in recipes)
            {
                Console.WriteLine(r.Name);
            }

            // Here is how to initialise a new recipe
            Recipe newRecipe = new Recipe("Pasta", "Test Description", new List<(string, int, string)>{ ("Pasta", 100, "g") }, new List<string>{"Boil water", "Add pasta"}, Categories.Dinner);
            
            //recipes.Add(newRecipe);

            recipeManager.SaveRecipes(recipes);
        }
    }
    
}