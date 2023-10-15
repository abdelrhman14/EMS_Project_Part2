using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class Presenter
    {
      
        [Key]
        public int Presenter_Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name not be exceed")]
        [DisplayName("Presenter")]
        public string? Name { get; set; }
        public int? Mobile { get; set; }

        public List<Sector_Presenter> Sector_Presenters { get; } = new();
        public List<Booking> Bookings { get; } = new();

        //public List<Sector> Sectors { get; } = new();

    }
}
