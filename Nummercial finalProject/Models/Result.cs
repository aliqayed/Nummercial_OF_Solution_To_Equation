

namespace Nummercial_finalProject.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        public double X { get; set; }
        public double y { get; set; }
        public int? ProblemId { get; set; }  // Foreign key to Result
        public virtual Problem? Problem { get; set; }
    
    }
}

