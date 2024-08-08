using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TasteBitesApi.Dtos.Recipes
{
    public class CreateRecipeDto
    {
        
        public string Name { get; set; } = String.Empty;
        public float PreparationTime { get; set; }
        public float Servings { get; set; }
        public int DificultyLevel { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Ingredients { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public string NutrionalValues { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        
    }
}