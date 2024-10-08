using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TasteBitesApi.Dtos.Recipes
{
    public class UpdateRecipeDto
    {
        
        public string Name { get; set; } = String.Empty;
        public float PreparationTime { get; set; }
        public float Servings { get; set; }
        public int DificultyLevel { get; set; }
        public string Description { get; set; } = String.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Instructions { get; set; } = new List<string>();
        public string NutrionalValues { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
    }
}