namespace RecipeManager
{
    public enum Categories {
            Uncategorised,
            Breakfast,
            Lunch,
            Dinner,
            Dessert,
            Snack,
            Drink,
            Other
        }
    public class Recipe
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<(string, int, string)>? Ingredients { get; set; } // (name, quantity, unit)
        public List<string>? Instructions { get; set; } // List of steps
        public Categories Category { get; set; }

        public Recipe(string name, string description, List<(string, int, string)> ingredients, List<string> instructions, Categories category)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Instructions = instructions;
            Category = category;
        }
    }
}