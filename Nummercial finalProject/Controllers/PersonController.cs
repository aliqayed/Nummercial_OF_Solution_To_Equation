namespace Nummercial_finalProject.Controllers
{
    public class PersonController : Controller
    {
        private readonly AppDBContext _context;

        public PersonController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            var stages = Enum.GetValues(typeof(Stages))
                             .Cast<Stages>()
                             .Select(stage => new SelectListItem
                             {
                                 Value = stage.ToString(),
                                 Text = stage.GetType()
                                            .GetField(stage.ToString())
                                            .GetCustomAttribute<DisplayAttribute>()
                                            ?.Name ?? stage.ToString()
                             })
                             .ToList();
            var governments = Enum.GetValues(typeof(Governments))
                        .Cast<Governments>()
                        .Select(government => new SelectListItem
                        {
                            Value = government.ToString(),
                            Text = government.GetType()
                                             .GetField(government.ToString())
                                             .GetCustomAttribute<DisplayAttribute>()
                                             ?.Name ?? government.ToString()
                        })
                        .ToList();

            ViewBag.Government = new
                SelectList(
                governments, "Value", "Text"
                );
            ViewBag.Stage = new
                SelectList
                (
                Enum.GetValues(typeof(Stages))
                .Cast<Stages>().
                Select(s => new SelectListItem
                {
                    Text = s.GetDisplayName(),
                    Value = s.ToString()
                }), "Value", "Text"
            );
            ViewBag.Stage = new SelectList(stages, "Value", "Text");
            return View();

        }


        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Telephone,Stage,LGovermentsSerialized,Note")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();

                
                return RedirectToAction("Create", "Problem");
            }

            
            return View(person);
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }
            var stages = Enum.GetValues(typeof(Stages))
                             .Cast<Stages>()
                             .Select(stage => new SelectListItem
                             {
                                 Value = stage.ToString(),
                                 Text = stage.GetType()
                                            .GetField(stage.ToString())
                                            .GetCustomAttribute<DisplayAttribute>()
                                            ?.Name ?? stage.ToString()
                             })

                             .ToList();
            var governments = Enum.GetValues(typeof(Governments))
                        .Cast<Governments>()
                        .Select(government => new SelectListItem
                        {
                            Value = government.ToString(),
                            Text = government.GetType()
                                             .GetField(government.ToString())
                                             .GetCustomAttribute<DisplayAttribute>()
                                             ?.Name ?? government.ToString()
                        })
                        .ToList();

            ViewBag.Government = new SelectList(governments, "Value", "Text");
            ViewBag.Stage = new SelectList(Enum.GetValues(typeof(Stages)).Cast<Stages>().Select(s => new SelectListItem
            {
                Text = s.GetDisplayName(),
                Value = s.ToString()
            }), "Value", "Text");



            ViewBag.Stage = new SelectList(stages, "Value", "Text");

            return View(person);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Telephone,Stage,LGovermentsSerialized,Note")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            if (person != null)
            {
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}

