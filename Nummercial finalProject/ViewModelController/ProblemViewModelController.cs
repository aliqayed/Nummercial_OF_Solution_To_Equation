

namespace Nummercial_finalProject.ViewModelController
{
    public class ProblemViewModelController
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Function name is required.")]
        public string NameFunction { get; set; } = string.Empty;

        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Initial value must be a valid number.")]
        public double InitialValue { get; set; } = 0.01;

        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Last value must be a valid number.")]
        public double LastValue { get; set; } = 0.02;

        [NotMapped]
        public double StepSize => LastValue - InitialValue;

        [Range(double.MinValue, double.MaxValue, ErrorMessage = "y0 must be a valid number.")]
        public double Y0 { get; set; } = 0.0;

        [Required]
        public Double H { get; set; }

        public int? PersonId { get; set; }  // Foreign key to Person
        public virtual Person? Person { get; set; }  // Navigation property to Person

        public int? ResultId { get; set; }  // Foreign key to Result
        public virtual Result? Result { get; set; }  // Navigation property to Result
    }
}
