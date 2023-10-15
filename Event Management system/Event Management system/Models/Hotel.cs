using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class Hotel
    {
        public Hotel()
        {
            Rooms = new List<Room>();
        }

        [Key]
        public int Hotel_Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name not be exceed")]
        public string? Name { get; set; }
        [Required]
        public string? Country { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Description { get; set; }
        public List<Room> Rooms { get; set; }
     //   public virtual ICollection<Room>? Rooms { get; set; }


    }
}
