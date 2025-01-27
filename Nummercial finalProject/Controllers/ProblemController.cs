namespace Nummercial_finalProject.Controllers
{
    public class ProblemController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IResultServices _IResultServices;

        public ProblemController
            (AppDBContext context, IResultServices resultServices)
        {
            _context = context;
            _IResultServices = resultServices;
        }


        public async Task<IActionResult> Index()
        {
            var appDBContext = _context.Problems.Include(p => p.Person).Include(p => p.Result);
            return View(await appDBContext.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem =
                await _context.Problems
                .Include(p => p.Person)
                .Include(p => p.Result)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }


        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName");
            ViewData["ResultId"] = new SelectList(_context.Results, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProblemId,NameFunction,InitialValue,LastValue,AnotherValue,X0,Y0,H")] Problem problem)
        {
            if (ModelState.IsValid)
            {

                _context.Add(problem);
                await _context.SaveChangesAsync();

                return RedirectToAction
                           ("SolVed", "ResultProblem",
                                  new { id = problem.Id });
            }

            return View(problem);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", problem.PersonId);
            ViewData["ResultId"] = new SelectList(_context.Results, "Id", "Id", problem.ResultId);
            return View(problem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProblemId,NameFunction,InitialValue,LastValue,AnotherValue,X0,Y0,Description,PersonId,ResultId")] Problem problem)
        {
            if (id != problem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Persons, "Id", "FirstName", problem.PersonId);
            ViewData["ResultId"] = new SelectList(_context.Results, "Id", "Id", problem.ResultId);
            return View(problem);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .Include(p => p.Person)
                .Include(p => p.Result)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var problem = await _context.Problems.FindAsync(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Drow()
        {
            var model = new
            {
                Slope = 2,
                Intercept = 3
            };
            return View(model);
        }
        private bool ProblemExists(int id)
        {
            return _context.Problems.Any(e => e.Id == id);
        }

    }
}

