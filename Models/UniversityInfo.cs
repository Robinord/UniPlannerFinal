using System.ComponentModel.DataAnnotations;

namespace UniPlanner.Models
{
    public class UniversityInfo
    {
        [Key]
        public int UniversityInfoID { get; set; }
        public required string Name { get; set; }
        public required string City { get; set; }
        public required string Region { get; set; }
        public required int THErank { get; set; }
        public required int QSrank { get; set; }
        public required int ARWUrank { get; set; }

        public ICollection<UniProgramme> UniProgrammes { get; set; }
    }
}
