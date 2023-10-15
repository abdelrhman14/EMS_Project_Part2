
using Azure;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class Sector_Presenter
    {
        [Key]
        public int Sector_Presenter_Id { get; set; }
        public int Presenter_Id { get; set; }
        public virtual Presenter? Presenter { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int Sector_Id { get; set; }
        public virtual Sector? Sector { get; set; }

    }
}
