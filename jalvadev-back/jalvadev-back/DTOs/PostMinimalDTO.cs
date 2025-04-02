namespace jalvadev_back.DTOs
{
    public class PostMinimalDTO
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
