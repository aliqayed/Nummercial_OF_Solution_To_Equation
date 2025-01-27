namespace Nummercial_finalProject.Controllers
{
    public class ProblemRController : Controller
    {
        public AppDBContext _context;
        public ProblemRController(AppDBContext _Context)
        {
            this._context = _Context;
        }



        public ActionResult Create()
        {

            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProblemR problem)
        {
            if (ModelState.IsValid)
            {

                _context.Add(problem);
                await _context.SaveChangesAsync();

                return RedirectToAction
                ("SolvedRangK", "ResultR",
                                  new { id = problem.Id });
            }

            return View(problem);

        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProblemRController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProblemRController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProblemRController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
