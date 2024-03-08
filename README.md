# Group Project: Recipe Management System
An Advanced Object-Oriented Programming (AOOP) assignment.
This is a continuation of https://github.com/nicki419/RecipeManager, after our group decided that they do not have time to do this assignment.

## Objective
Develop a console application that allows users to manage their cooking recipes. The application will enable users to:
- Create, view, update, and categorize recipes
- Search for recipes based on ingredients or categories
- Manage categories (organize recipes into different categories and manage these categories - create new ones, update or delete existing ones, and reassign recipes to different categories)
- Ensure recipes are updated to reflect category changes
- Automatically assign recipes to a “Default” category if their category is deleted
- Achieve data persistence through JSON files, allowing users to maintain their recipe collections across sessions
- Collaborative coding using Git and code quality assurance through unit testing with xUnit

## Required Components
### IRecipe Interface
- Specifies methods for adding, viewing, updating, and categorizing recipes.

### IRecipeStorage Interface
- Specifies methods for loading and saving recipe data.

### Recipe Class
- Properties: Recipe ID (Guid), Title (string), Ingredients (List<string>), Instructions (string), Category (string).
- ID uses the type Guid (i.e., `public Guid ID { get; set; } = Guid.NewGuid();`).
- Constructor initializes a recipe with the provided details.

### RecipeManager Class
- Implements the IRecipe interface, managing a list of Recipe objects. Includes functionality to add, update, categorize, and search for recipes.

### JsonRecipeStorage Class
- Implements the IRecipeStorage interface, handling persistence by reading from and writing to a `recipes.json` file.

### Program Class (User Interface)
- Provides a console-based UI for user interaction, enabling recipe management operations.

## Technical Requirements
- **JSON Data Persistence**: Implement with `System.Text.Json` to manage recipe data effectively.
- **Robust Recipe Management**: Include methods in RecipeManager for comprehensive recipe handling.
- **Exception Handling and Input Validation**: Ensure user-friendly error management for data and operations.
- **Git for Collaborative Coding**: Utilize Git for version control, emphasizing regular commits and proper workflow practices.
- **xUnit Testing**: Integrate xUnit for unit testing, covering all functionalities including recipe and category management.

## xUnit Testing Requirements
- **Unit Tests Setup**: Establish a separate xUnit test project within the solution. Reference the main project to access the Recipe Management System's functionalities.
- **Recipe Class Tests**: Constructor_AssignsCorrectValues, Property_SettersAndGetters.
- **RecipeManager Class Tests**: AddRecipe_AddsRecipeToList, UpdateRecipe_UpdatesExistingRecipe, DeleteRecipe_RemovesRecipeFromList, GetRecipe_ReturnsCorrectRecipe, SearchRecipes_FiltersByCategory, SearchRecipes_FiltersByIngredient, CategorizeRecipes_AssignsCorrectCategory, UpdateCategory_UpdatesExistingCategory, DeleteCategory_RemovesCategoryAndReassignsRecipes.
- **JsonRecipeStorage Class Tests**: LoadRecipes_LoadsDataFromFile, SaveRecipes_SavesDataToFile, LoadRecipes_ThrowsExceptionOnInvalidData.
- **Integration and Continuous Testing**: Configure continuous integration (CI) using GitHub Actions to automate running of xUnit tests on every commit.

## Example Workflow
- **Application Initialization**: Starts by loading existing recipe data from `recipes.json`. If the file does not exist, it initializes with an empty list of recipes.
- **Main Menu Presentation**: Users are presented with a menu for various actions: add a new recipe, view all recipes, update an existing recipe, search for recipes, manage recipe categories, or exit the application.
- **Adding a New Recipe**: Prompts the user for details (title, ingredients, instructions, category), creating a new recipe entry.
- **Viewing All Recipes**: Displays the entire list of recipes with options to filter by category or ingredients.
- **Updating an Existing Recipe**: Allows users to modify any details of an existing recipe.
- **Searching for Recipes**: Users can find recipes based on ingredients or categories.
- **Managing Recipe Categories**: Users can create, update, delete categories, and reassign recipes to different categories.
- **Exiting the Application**: Saves the current state of all recipes and categories to `recipes.json` file.

## Authors
- [@svenons](https://github.com/svenons/)

## Acknowledgements
- Originally started at [Nicki419 - RecipeManager](https://github.com/nicki419/RecipeManager)
- This exercise is part of Advanced Object-Oriented Programming on [Software Engineering at SDU](https://mitsdu.dk/en/mit_studie/bachelor/softwareengineering_bachelor_soenderborg).
- Created by [Maximus D. Kaos](https://github.com/MaxDKaos/) and [Maximilian von Zastrow](https://github.com/vzastrow).
