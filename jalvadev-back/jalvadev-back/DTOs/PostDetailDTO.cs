namespace jalvadev_back.DTOs
{
    public class PostDetailDTO
    {
        public int Id { get; set; }

        public UserDTO User { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
