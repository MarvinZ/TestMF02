using System.ComponentModel.DataAnnotations.Schema;

namespace quiz_backend.Models
{
    [Table("Feed")]

    public class Feed
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string url { get; set; }
        public bool isSubscribed { get; set; } = false;
    }
}
