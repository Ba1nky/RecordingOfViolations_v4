using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordingOfViolations.Models
{
    public class PaymentСheck
    {
        public int PaymentСheckId { get; set; }
        public string PaymentType { get; set; } = null!;
        public string Payer { get; set; } = null!;
        public DateTime Date { get; set; }
        public int ViolationId { get; set; }
        public Violation Violation { get; set; } = null!;
    }
}
