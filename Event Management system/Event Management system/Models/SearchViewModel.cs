using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class SearchViewModel
    {
        [Key]
        public int SearchViewModel_Id { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public IList<Room> Room { get; set; } = new List<Room>();
    }
}
