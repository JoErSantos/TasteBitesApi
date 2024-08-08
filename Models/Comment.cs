namespace TasteBitesApi.Models
{
    public class Comment
    {
        //Props
        public int Id { get; set; } //PK
        public string Content { get; set; } = String.Empty;
        public int Likes { get; set; } = 0;
        public DateTime CreationDate { get; set; } = DateTime.Now;

        //FKs
        public int RecipeId { get; set; }
        public Recipe recipe { get; set;}  //Navigation properties
        public string UserId { get; set; }
        public User user{ get; set; }  //Navigation properties

        
        

    }
}