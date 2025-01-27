

namespace Nummercial_finalProject.Controllers
{
    public class ResultRController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IResultServices _IResultServices;
        private readonly IMapper _mapper;
        public ResultRController(AppDBContext context, IResultServices _IResultServices, IMapper mapper)
        {
            this._context = context;
            this._IResultServices = _IResultServices;
            this._mapper = mapper;
        }

        public async Task<IActionResult> SolvedRangK(int id)
        {
            if (ModelState.IsValid)
            {
                
                var problem = await _context.ProblemsR.FindAsync(id);

                if (problem == null)
                {
                    return NotFound(); 
                }

               
                TempData["SHapeFunction"] = problem.NameFunction;
                TempData["x0"] = problem.InitialValue.ToString();
                TempData["y0"] = problem.Y0.ToString();

             
                var REresult_r = await _IResultServices.Rangku(problem);
                var resultViewModels = _mapper.Map<List<ResultRViewModelController>>(REresult_r);

                await _context.SaveChangesAsync();

       
                return View(resultViewModels);
            }

         
            return View("Error");

        }


    }
}
