using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class Investor
    {
    
        [Key]
        public int Investor_Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name not be exceed")]
        [DisplayName("Investor")]
        public string? Name { get; set; }
        public int? Mobile { get; set; }
        public List<Sector_Investor>? Sector_Investors { get; set; }

        public List<MatchingViewModel> MatchingViewModels { get; } = new();
        public List<Booking> Bookings { get; } = new();


    }
}
