namespace jalvadev_back.DTOs
{
    public class PagerDTO<T>
    {
        public List<T> Data { get; set; } = new List<T>();

        public int CurrentPage { get; set; }

        public int NumOfItems { get; set; }

        public int TotalPages { get; set; }
    }
}
