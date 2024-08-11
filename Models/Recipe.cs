using System.ComponentModel.DataAnnotations.Schema;

namespace TasteBitesApi.Models
{
    [Table("Recipe")]
    public class Recipe
    {
        //Props
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
        public long RatingTotalVotes { get; set; } = 0;
        public string Category { get; set; } = String.Empty;
        public DateTime CreationTime = DateTime.Now;

        //FKs
        public string CreatorID { get; set; }
        public User User { get; set; } //Navigation propertie

        //FKs Relations
        public List<Comment> Comments { get; set; }  = new List<Comment>();
    }
}