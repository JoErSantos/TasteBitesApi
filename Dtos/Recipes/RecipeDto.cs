using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteBitesApi.Models;

namespace TasteBitesApi.Dtos.Recipes
{
    public class RecipeDto
    {
        
        public string Name { get; set; } = String.Empty;
        public float PreparationTime { get; set; }
        public float Servings { get; set; }
        public int DificultyLevel { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Ingredients { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public string NutrionalValues { get; set; } = String.Empty;
        public long Likes { get; set; } = 0;
        public float Rating { get; set; } = 0;

        //FKs
        public string CreatorID { get; set; }

        //FKs Relations
        public List<Comment> Comments { get; set; }  = new List<Comment>();
    }
}