using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_system.Models
{
    public class Booking
    {
        [Key]
        public int Booking_Id { get; set; }
        [ForeignKey("Investor")]
        public int Investor_Id { get; set; }
        public virtual Investor? Investor { get; set; }
        [ForeignKey("Presenter")]

        public int Presenter_Id { get; set; }
        public virtual Presenter? Presenter { get; set; }
        [ForeignKey("Room")]

        public int Room_Id { get; set; }
        public virtual Room? Room { get; set; }

    }
}
