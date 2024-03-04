namespace RecipeManager
{
    public class TextInterface
    {
        // MainMenu mainMenu = new MainMenu();
        RecipeManager recipeManager = new RecipeManager();
        public void MainMenu()
        {
            // Display the main menu
            List<string> mainMenuChoices = new List<string> { "View Recipes", "Add Recipe", "Remove Recipe", "Update Recipe", "Categorise Recipe"};
            while (true)
            {
                int choice = TextChoice(mainMenuChoices);
                switch (choice)
                {
                    case 1:
                        ListRecipes();
                        break;
                    case 2:
                        //recipeManager.AddRecipe();
                        break;
                    case 3:
                        //recipeManager.RemoveRecipe();
                        break;
                    case 4:
                        //recipeManager.UpdateRecipe();
                        break;
                    case 5:
                        //recipeManager.CategoriseRecipe();
                        break;
                    case 0:
                        return;
                }
            }
        }
        public int TextChoice(List<string> choises, int exit = 1)
        {
            Console.Clear();
            int choice;
            do
            {
                for (int i = 0; i < choises.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {choises[i]}");
                }
                if (exit == 1)
                {
                    Console.WriteLine("0. Exit");
                }
                else if (exit == 2)
                {
                    Console.WriteLine("0. Back");
                }

                Console.Write("\n>> ");
                string? input = Console.ReadLine();
                if (int.TryParse(input, out choice))
                {
                    if (exit == 1 || exit == 2) {
                        if (choice >= 0 && choice <= choises.Count)
                        {
                            return choice;
                        }
                    }
                    else
                    {
                        if (choice >= 1 && choice <= choises.Count)
                        {
                            return choice;
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine("Invalid choice. Please try again. \n");
            } while (true);

            // Process the valid choice here
            // ...

        }
    
        public void ListRecipes()
        {
            var recipes = recipeManager.GetRecipes();
            Console.Clear();
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"({recipe.Category})\n{recipe.Name}: {recipe.Description}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients!)
                {
                    Console.WriteLine(" - " + ingredient);
                }
                Console.WriteLine("Instructions:");
                foreach (var instruction in recipe.Instructions!)
                {
                    Console.WriteLine(" - " + instruction);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }
    }
}