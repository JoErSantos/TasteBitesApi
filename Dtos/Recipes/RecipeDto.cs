using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TasteBitesApi.Models;

namespace TasteBitesApi.Dtos.Recipes
{
    public class RecipeDto
    {
        public int Id { get; set; } //PK
        public string Name { get; set; } = String.Empty;
        public float PreparationTime { get; set; }
        public float Servings { get; set; }
        public int DificultyLevel { get; set; }
        public string Description { get; set; } = String.Empty;
        public List<string> Ingredients { get; set; } = new List<string>();
        public List<string> Instructions { get; set; } = new List<string>();
        public string NutrionalValues { get; set; } = String.Empty;
        public long Likes { get; set; } = 0;
        public float Rating { get; set; } = 0;
        public string Category { get; set; } = String.Empty;
        public DateTime CreationTime = DateTime.Now;
        public string CreatorID { get; set; } = String.Empty;
        //FKs Relations
        public List<Comment> Comments { get; set; }  = new List<Comment>();
    }
}