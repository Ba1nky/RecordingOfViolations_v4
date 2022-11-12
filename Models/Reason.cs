using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RecordingOfViolations.Models
{
    public class Reason
    {
        public int ReasonId { get; set; }
        public string Name { get; set; } = null!;

        public List<Violation> Violations { get; set; } = new List<Violation>();
    }
}
