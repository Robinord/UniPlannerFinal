using System.ComponentModel.DataAnnotations;
using UniPlanner.Models;


namespace UniPlanner.Models
{
    public class Programme
    {
        [Key]
        public int ProgrammeID { get; set; }
        public required string Name { get; set; }

        public ICollection<UniProgramme> UniProgrammes { get; set; }
    }
}
