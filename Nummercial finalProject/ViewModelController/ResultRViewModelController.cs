namespace Nummercial_finalProject.ViewModelController
{
    public class ResultRViewModelController
    {
        [Key]
        public int Id { get; set; }

        public double X { get; set; }
        public double y { get; set; }
        public int? ProblemIdR { get; set; }  
        public virtual ProblemR? ProblemR { get; set; }
    }
}
