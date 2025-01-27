namespace Nummercial_finalProject.Controllers
{
    public class ResultProblemController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IResultServices _IResultServices;
        public ResultProblemController
           (AppDBContext context, IResultServices resultServices)
        {
            _context = context;
            _IResultServices = resultServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SolVed(int id)
        {
            try
            {
                var problem =
                    await _context.Problems.FindAsync(id);

                if (problem == null)
                    return NotFound();
                TempData["SHapeFunction"] = problem.NameFunction.ToString();
                TempData["x0"] = problem.InitialValue.ToString();
                TempData["y0"] = problem.Y0.ToString();
                var REresult = _IResultServices.Solve(problem);
                _context.Results.AddRangeAsync(REresult);
                _context.SaveChanges();
                return View(REresult);
            }
            catch (Exception ex)
            {

                return View("Error");
            }
        }

    }
}
