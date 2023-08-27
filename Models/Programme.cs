using System.ComponentModel.DataAnnotations;
using UniPlanner.Models;


namespace UniPlanner.Models
{
    public class Programme
    {
        [Key]
        public required int ProgrammesID { get; set; }
        public required string Name { get; set; }

        public ICollection<UniProgramme> UniProgrammes { get; set; }
    }
}
