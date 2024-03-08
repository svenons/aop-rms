namespace RecipeManager
{
    public class TextInterface
    {
        // MainMenu mainMenu = new MainMenu();
        RecipeManager recipeManager = new RecipeManager();
        public void MainMenu()
        {
            // Display the main menu
            List<string> mainMenuChoices = new List<string> { "View Recipes", "Add Recipe", "Remove Recipe", "Update Recipe"};
            while (true)
            {
                int choice = TextChoice(mainMenuChoices);
                switch (choice)
                {
                    case 1:
                        ListRecipes();
                        break;
                    case 2:
                        AddRecipe();
                        break;
                    case 3:
                        RemoveRecipe();
                        break;
                    case 4:
                        UpdateRecipe();
                        break;
                    case 0:
                        var recipes = recipeManager.GetRecipes();
                        recipeManager.SaveRecipes(recipes);
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
    
        public void AddRecipe()
        {
            Console.Clear();
            string name, description;
            List<(string, int, string)> ingredients = new List<(string, int, string)>();
            List<string> instructions = new List<string>();
            Categories category;

            // Input for name
            do
            {
                Console.WriteLine("Please enter the recipe name:");
                Console.Write(">> ");
                name = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(name)) break;
                Console.Clear();
                Console.WriteLine("Input must be valid. Please enter the name.\n");
            } while (true);

            // Input for description
            do
            {
                Console.WriteLine("Please enter the recipe description:");
                Console.Write(">> ");
                description = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(description)) break;
                Console.Clear();
                Console.WriteLine("Input must be valid. Please enter the description.\n");
            } while (true);

            // Input for ingredients
            string ingredientName, ingredientType;
            int ingredientAmount;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter ingredient name:");
                Console.Write(">> ");
                ingredientName = Console.ReadLine()!;

                Console.WriteLine("Enter ingredient amount (number):");
                Console.Write(">> ");
                while (!int.TryParse(Console.ReadLine(), out ingredientAmount) || ingredientAmount <= 0)
                {
                    Console.WriteLine("Input must be a valid number greater than 0. Please enter the amount:\n>> ");
                }

                Console.WriteLine("Enter ingredient type (e.g., g, ml, cups):");
                Console.Write(">> ");
                ingredientType = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(ingredientName) && !string.IsNullOrWhiteSpace(ingredientType))
                {
                    ingredients.Add((ingredientName, ingredientAmount, ingredientType));
                }
                else
                {
                    Console.WriteLine("Ingredient details must be valid.\n");
                    continue;
                }

                Console.WriteLine("Do you want to add another ingredient? (yes/no)");
                Console.Write(">> ");
            } while (Console.ReadLine()!.Trim().ToLower() == "yes");

            // Input for instructions
            string instruction;
            do
            {
                Console.Clear();
                Console.WriteLine("Current instructions:");
                foreach (var inst in instructions)
                {
                    Console.WriteLine($" - {inst}");
                }

                Console.WriteLine("\nEnter instruction:");
                Console.Write(">> ");
                instruction = Console.ReadLine()!;
                if (!string.IsNullOrWhiteSpace(instruction))
                {
                    instructions.Add(instruction);
                }
                else
                {
                    Console.WriteLine("Instruction must be valid.\n");
                    continue;
                }

                Console.WriteLine("Do you want to add another instruction? (yes/no)");
                Console.Write(">> ");
            } while (Console.ReadLine()!.Trim().ToLower() == "yes");

            // Input for category
            do
            {
                Console.WriteLine("Please enter the recipe category (e.g., Breakfast, Lunch, Dinner, Snack):");
                Console.Write(">> ");
                if (Enum.TryParse(Console.ReadLine(), out category) && Enum.IsDefined(typeof(Categories), category))
                {
                    break;
                }
                Console.Clear();
                Console.WriteLine("Input must be a valid category. Please enter the category.\n");
            } while (true);

            // Create and add the new recipe
            Recipe newRecipe = new Recipe(name, description, ingredients, instructions, category);
            recipeManager.AddRecipe(newRecipe);
            Console.Clear();
            Console.WriteLine("Recipe added successfully!");
        }
    
        public void UpdateRecipe()
        {
            List<Recipe> recipes = recipeManager.GetRecipes();
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to update.");
                return;
            }

            Console.WriteLine("Select a recipe to update:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            int choice = -1;
            while (choice < 0 || choice >= recipes.Count)
            {
                Console.Write(">> ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    choice = -1;
                    continue;
                }
            }

            if (choice < 0 || choice >= recipes.Count)
            {
                Console.WriteLine("Invalid selection. Returning to the main menu.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Recipe oldRecipe = recipes[choice];
            Recipe newRecipe = oldRecipe;

            newRecipe = UpdateRecipeDetails(newRecipe);

            recipeManager.UpdateRecipe(oldRecipe, newRecipe);
            Console.WriteLine("Recipe updated successfully!");
        }

        private Recipe UpdateRecipeDetails(Recipe recipe)
        {
            Console.WriteLine("What would you like to update?");
            List<string> options = new List<string> { "Name", "Description", "Ingredients", "Instructions", "Category" };
            int option = TextChoice(options, 2);

            switch (option)
            {
                case 1:
                    Console.Write("Enter new name: ");
                    recipe.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter new description: ");
                    recipe.Description = Console.ReadLine();
                    break;
                case 3:
                    recipe.Ingredients = UpdateRecipeIngredients();
                    break;
                case 4:
                    recipe.Instructions = UpdateRecipeInstructions();
                    break;
                case 5:
                    Console.Write("Enter new category: ");
                    recipe.Category = (Categories)Enum.Parse(typeof(Categories), Console.ReadLine()!, true);
                    break;
            }

            return recipe;
        }

        private List<(string, int, string)> UpdateRecipeIngredients() // I am too lazy to implement checking for valid inputs now and this is taking forever
        {
            var newIngredients = new List<(string, int, string)>();
            Console.WriteLine("Enter new ingredients. Type 'done' when you are finished:");

            while (true)
            {
                Console.WriteLine("Enter ingredient name (or 'done' to finish):");
                Console.Write(">> ");
                string name = Console.ReadLine()!;
                if (name.ToLower() == "done") break;

                int amount;
                Console.WriteLine("Enter ingredient amount:");
                Console.Write(">> ");
                while (!int.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Please enter a valid number greater than 0.");
                    Console.Write(">> ");
                }

                Console.WriteLine("Enter ingredient unit (e.g., g, ml, cups):");
                Console.Write(">> ");
                string unit = Console.ReadLine()!;

                newIngredients.Add((name, amount, unit));
                Console.WriteLine("Ingredient added. Add another or type 'done' to finish.");
            }

            return newIngredients;
        }


        private List<string> UpdateRecipeInstructions()
        {
            var newInstructions = new List<string>();
            Console.WriteLine("Enter new instructions. Type 'done' when you are finished:");
            int instructionNumber = 1;

            while (true)
            {
                Console.WriteLine($"Enter instruction #{instructionNumber} (or 'done' to finish):");
                Console.Write(">> ");
                string instruction = Console.ReadLine()!;
                if (instruction.ToLower() == "done") break;

                newInstructions.Add(instruction);
                instructionNumber++;
                Console.WriteLine("Instruction added. Add another or type 'done' to finish.");
            }

            return newInstructions;
        }

        public void RemoveRecipe()
        {
            List<Recipe> recipes = recipeManager.GetRecipes();
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available to remove.");
                return;
            }

            Console.WriteLine("Select a recipe to remove:");
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }

            int choice = -1;
            while (choice < 0 || choice >= recipes.Count)
            {
                Console.Write(">> ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    choice = -1;
                    continue;
                }
            }

            if (choice < 0 || choice >= recipes.Count)
            {
                Console.WriteLine("Invalid selection. Returning to the main menu.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Recipe removeRecipe = recipes[choice];
            recipeManager.RemoveRecipe(removeRecipe);
            +
    }
}