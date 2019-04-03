namespace hic.restaurant.Models
{
    public class Table
    {
        public string Id { get; set; }
        public int Seats { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsBookable { get; set; }
    }
}
