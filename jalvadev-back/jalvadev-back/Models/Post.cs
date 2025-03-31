using System.ComponentModel.DataAnnotations;

namespace jalvadev_back.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public required string Title { get; set; }

        public required string Content { get; set; }

        public bool IsDraft { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}
