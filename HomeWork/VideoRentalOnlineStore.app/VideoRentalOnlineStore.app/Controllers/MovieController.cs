using Microsoft.AspNetCore.Mvc;
using VROS.DataAccess.Interfaces;
using VROS.DataAccess.Repository;
using VROS.Domain;
using VROS.VM;

namespace VideoRentalOnlineStore.app.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IRentalRepository _rentalRepo;
        private readonly IUserRepository _userRepo;

        public MovieController(IMovieRepository movieRepo, IRentalRepository rentalRepo, IUserRepository userRepo)
        {
            _movieRepo = movieRepo;
            _rentalRepo = rentalRepo;
            _userRepo = userRepo;
        }

        // GET: /Movie
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account");

            var movies = await _movieRepo.GetAllMoviesAsync();
            var vm = movies.Select(m => new MovieListVM
            {
                Id = m.Id,
                Title = m.Title,
                Genre = m.Genre,
                Quantity = m.Quantity
            });

            return View(vm);
        }

        // GET: /Movie/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account");

            var movie = await _movieRepo.GetMovieByIdAsync(id);
            if (movie == null)
                return NotFound();

            var vm = new MovieDetailVM
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };

            return View(vm);
        }

        // POST: /Movie/Rent/5
        [HttpPost]
        public async Task<IActionResult> Rent(int id)
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
                return RedirectToAction("Login", "Account");

            var movie = await _movieRepo.GetMovieByIdAsync(id);
            if (movie == null || movie.Quantity <= 0)
            {
                TempData["Error"] = "Movie not available for rent.";
                return RedirectToAction("Details", new { id });
            }

            var rental = new Rental
            {
                UserId = userId.Value,
                MovieId = id,
                RentedOn = DateTime.Now,
                ReturnedOn = null
            };

            await _rentalRepo.AddRentalAsync(rental);

            movie.Quantity--;
            await _movieRepo.UpdateMovieAsync(movie);

            TempData["Success"] = $"You rented '{movie.Title}'.";
            return RedirectToAction("Details", new { id });
        }
    }
}