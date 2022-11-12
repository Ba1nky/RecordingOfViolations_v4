using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordingOfViolations.Models
{
    public class Violation
    {
        public int ViolationId { get; set; }

        [Required(ErrorMessage = "Адреса не повина бути пустною")]
        [Display(Name = "Адреса")]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = "ПІБ іспектора не повині бути пустними")]
        [Display(Name = "Іспектор")]
        public string Policeman { get; set; } = null!;

        [Required(ErrorMessage = "ПІБ порушника не повині бути пустними")]
        [Display(Name = "Порушник")]
        public string Offender { get; set; } = null!;

        [Required(ErrorMessage = "Сума штрафу не повина бути пустною")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Сума штрафу")]
        public decimal? Price { get; set; }

        [Display(Name = "Дата")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; } = DateTime.Now;

        public int? ReasonId { get; set; }
        public Reason? Reason { get; set; }

        public List<PaymentСheck> PaymentСhecks { get; set; } = new List<PaymentСheck>();
    }
}
