using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public enum FEnum
    {
        [Display(Name = "Available")]
        Available = 0,
        [Display(Name = "Booked")]
        Booked =1
    }
}
