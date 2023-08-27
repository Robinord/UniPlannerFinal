using System.ComponentModel.DataAnnotations;

namespace UniPlanner.Models
{
    public class MajorsOffered
    {
        [Key]
        public int MajorsOfferedID { get; set; }
        public required UniProgramme UniProgramme { get; set; }
        public required string Name { get; set; }
        public string Link { get; set; }
    }
}
