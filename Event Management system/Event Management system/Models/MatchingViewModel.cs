using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class MatchingViewModel
    {
        [Key]
        public int MV_Id { get; set; }
        public int Investor_Id { get; set; }
        public virtual Investor? Investors { get; set; }
        public int Sector_Id { get; set; }
        public Sector? Sector { get; set; }
        public int Presenter_Id { get; set; }
        public virtual Presenter? Presenters { get; set; }
        public DateTime FromDate_Investor { get; set; }
        public DateTime ToDate_Investor { get; set; }
        public DateTime FromDate_Presenter { get; set; }
        public DateTime ToDate_Presenter { get; set; }
      


    }
}
