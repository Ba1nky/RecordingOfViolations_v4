using RecordingOfViolations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace RecordingOfViolations.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ViolationContext _context;

        public HomeController(ViolationContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var violations = _context.Violations.Include(v => v.Reason)
                .ToList();

            return View(_context.Violations);
        }

        [HttpGet]
        public ActionResult Pay(int id)
        {
            ViewBag.ViolationId = id;
            return View();
        }

        [HttpPost]
        public string Pay(PaymentСheck paymentСheck)
        {
            paymentСheck.Violation = _context.Violations.FirstOrDefault(v => v.ViolationId == paymentСheck.ViolationId)!;

            _context.Add(paymentСheck);
            _context.SaveChanges();

            return $"Дякую, {paymentСheck.Payer}, за оплату!\n" +
                $"Пам'ятай, у грі ти можеш ганяти без будь-яких правил 🏍\n" +
                $"Але ... В житті будь уважним на дорозі!\n" +
                $"Та пристягни ремень 😎";
        }

        [HttpGet]
        public ActionResult EditViolation(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Violation? violation = _context.Violations.FirstOrDefault(v => v.ViolationId == id);

            if (violation is not null)
            {
                SelectList reasons = new SelectList(_context.Reasons, "ReasonId", "Name");
                ViewBag.Reasons = reasons;

                return View(violation);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult EditViolation(Violation violation)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(violation).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList reasons = new SelectList(_context.Reasons, "ReasonId", "Name");
            ViewBag.Reasons = reasons;

            return View(violation);
        }

        [HttpGet]
        public ActionResult CreateViolation()
        {
            SelectList reasons = new SelectList(_context.Reasons, "ReasonId", "Name");
            ViewBag.Reasons = reasons;

            return View();
        }

        [HttpPost]
        public ActionResult CreateViolation(Violation violation)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                _context.Violations.Add(violation);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            SelectList reasons = new SelectList(_context.Reasons, "ReasonId", "Name");
            ViewBag.Reasons = reasons;

            return View(violation);
        }

        [HttpGet]
        public ActionResult DeleteViolation(int id)
        {
            Violation? violation = _context.Violations.Include(p => p.Reason)
                .FirstOrDefault(p => p.ViolationId == id);

            if (violation is null)
            {
                return NotFound();
            }

            return View(violation);
        }

        [HttpPost, ActionName("DeleteViolation")]
        public ActionResult DeleteConfirmed(int id)
        {
            Violation? violation = _context.Violations.FirstOrDefault(p => p.ViolationId == id);

            if (violation is null)
            {
                return NotFound();
            }

            _context.Violations.Remove(violation);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}