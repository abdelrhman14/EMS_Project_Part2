using Azure;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event_Management_system.Models
{
    public class Sector
    {
        [Key]
        public int Sector_Id { get; set; }
        [DisplayName("Sector")]
        public string? Name { get; set; }

      //  public List<Sector_Presenter> ManyToManys { get; } = new();
     //   public List<Presenter> Presenters { get; } = new();
///
        public List<Sector_Investor> Sector_Investors { get; } = new();
        public List<Sector_Presenter> Sector_Presenters { get; } = new();
        public List<MatchingViewModel> MatchingViewModels { get; } = new();

    }
} 
