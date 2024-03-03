using Newtonsoft.Json;
namespace RecipeManager
{
    public class JsonRecipeStorage : IRecipeStorage
    {
        private const string FilePath = "data.json";

        public void SaveRecipes(List<Recipe> recipes)
        {
            string json = JsonConvert.SerializeObject(recipes);
            File.WriteAllText(FilePath, json);
        }

        public List<Recipe> LoadRecipes()
        {
            if (File.Exists(FilePath))

            {
                string json = File.ReadAllText(FilePath);
                try 
                {
                    List<Recipe> recipes = JsonConvert.DeserializeObject<List<Recipe>>(json)!;
                    return recipes;
                }
                catch (JsonException)
                {
                    throw new InvalidDataException("Invalid data at " + FilePath);
                }
            }
            else
            {
                // file not found
                List<Recipe> recipes = new List<Recipe>();
                return recipes;
            }
        }
    }
}