namespace Nummercial_finalProject.Services
{
    public interface IResultServices
    {
        public List<Result> Solve(Problem problem);
        public Task< List<ResultR> >Rangku(ProblemR problem);
    }
}
