using Microsoft.AspNetCore.Mvc;
using MVCtest.Models;

namespace MVCtest.Controllers
{
    [Route("Counter/[action]")]
    public class CounterController : Controller 
    {
        private List<Counter> _counters;
        private Counter _currentCounter;

        public CounterController()
        {
            _counters = new List<Counter>();        // Initialize empty list of counters
            _currentCounter = new Counter();        // Create a new counter
            _counters.Add(_currentCounter);         // Add the counter to the list
        }

        public IActionResult Index()
        {
            return View(_currentCounter);
        }

        public IActionResult clickerBegin() 
        {
            _currentCounter = new Counter();
            _counters.Add(_currentCounter);
            return View(_currentCounter);
        }

        [HttpPost] // Handles button clicks
        public IActionResult incrementCounter()
        {
            _currentCounter._count++;
            return RedirectToAction("Index");
        }
    }
}
