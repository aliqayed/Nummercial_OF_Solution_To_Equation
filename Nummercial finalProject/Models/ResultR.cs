

namespace Nummercial_finalProject.Models
{
    public class ResultR
    {
        [Key]
        public int Id { get; set; }

        public double X { get; set; }
        public double y { get; set; }
        public int? ProblemRId { get; set; }
        [Ignore]
        public virtual ProblemR? ProblemR { get; set; }
    }
}
