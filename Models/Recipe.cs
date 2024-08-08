using System.ComponentModel.DataAnnotations.Schema;

namespace TasteBitesApi.Models
{
    [Table("Recipes")]
    public class Recipe
    {
        //Props
        public int Id { get; set; } //PK
        public string Name { get; set; } = String.Empty;
        public float PreparationTime { get; set; }
        public float servings { get; set; }
        public int dificultyLevel { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Ingredients { get; set; } = String.Empty;
        public string Instructions { get; set; } = String.Empty;
        public string NutrionalValues { get; set; } = String.Empty;
        public long Likes { get; set; }
        public float Rating { get; set; }
        public string Category { get; set; } = String.Empty;

        //FKs
        public string CreatorID { get; set; }
        public User User { get; set; } //Navigation propertie

        //FKs Relations
        public List<Comment> Comments { get; set; }  = new List<Comment>();
    }
}