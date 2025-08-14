using System.ComponentModel.DataAnnotations.Schema;

namespace GreenWorld.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Content { get; set; }
        public string? Content2 { get; set; }
        public string? Content3 { get; set; }
        public string? Content4 { get; set; }
        public string? ImagePath { get; set; }  
        public string? ImagePath2 { get; set; }  
        public string? ImagePath3 { get; set; }  
    }
}
