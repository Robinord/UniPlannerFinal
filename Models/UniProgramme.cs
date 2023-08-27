using System.ComponentModel.DataAnnotations;

namespace UniPlanner.Models
{
    public class UniProgramme
    {
        [Key]
        public int UniProgrammeID { get; set; }
        public required UniversityInfo UniversityID { get; set; }
        public required Programme ProgrammeID { get; set; }
        public required string Link { get; set; }
        [Range(0, 320, ErrorMessage = "Please enter correct value")]
        public int? RankScore { get; set; }
        public required ICollection<MajorsOffered> MajorsOffereds { get; set; }
    }
}
