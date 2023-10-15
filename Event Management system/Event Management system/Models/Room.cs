using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace Event_Management_system.Models
{
    public class Room : IValidatableObject
    {

        [Key]
        public int Room_Id { get; set; }
        public string? Name { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
       
        public FEnum Status { get
            {
                if (this.Bookings.Count() == 0)
                    return (FEnum)0;
                else
                    return (FEnum)1;
            }
                
                
                }

        [ForeignKey("Hotel")]
        public int Hotel_Id { get; set; }
        public virtual Hotel? Hotel { get; set; }

        public List<Booking> Bookings { get; } = new();


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ToDate < FromDate || (FromDate - ToDate).TotalHours > 1)
            {
                yield return new ValidationResult("Invalid date");
            }
          
        }


    }
}
