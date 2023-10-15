using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Event_Management_system.Models
{
    public class Sector_Investor
    {
        [Key]
        public int Sector_Investor_Id { get; set; }
        public int Investor_Id { get; set; }
        public virtual Investor? Investor { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public  int Sector_Id { get; set; }
        public Sector? Sector { get; set; }



    }

    class MyViewModel
    {
        public List<Sector_Investor> SemesterFaculties { get; set; }

    }
}

