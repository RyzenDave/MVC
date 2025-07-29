using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VROS.DataAccess;
using VROS.DataAccess.Interfaces;
using VROS.Domain;
using VROS.Domain.Enums;
using VROS.Mapper;
using VROS.VM;

namespace VideoRentalOnlineStore.app.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepo;
        private readonly IUserRepository _userRepo;

        public MovieController(IMovieRepository movieRepo, IUserRepository userRepo)
        {
            _movieRepo = movieRepo;
            _userRepo = userRepo;
        }

        // Helper: Check if current user is Admin
        private async Task<bool> IsAdminAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue) return false;
            var user = await _userRepo.GetByIdAsync(userId.Value);
            return user?.Roles == UserRoles.Admin;
        }

        // GET: /Movie - Available to ALL logged-in users


        // GET: /Movie/Details/5 - Available to ALL
        MovieDetailVM.ToDetailVM(Movie, movie)

        //  Admin Only: Show Create Form
        public async Task<IActionResult> Create()
        {
            if (!await IsAdminAsync())
            {
                TempData["Error"] = "Access denied. Admins only.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //  Admin Only: Handle Create
        [HttpPost]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (!await IsAdminAsync())
                return Forbid();

            if (ModelState.IsValid)
            {
                movie.Id = StaticDb.Movies.Count + 1;
                StaticDb.Movies.Add(movie);
                TempData["Success"] = "Movie added successfully.";
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // Admin Only: Show Edit Form
        public async Task<IActionResult> Edit(int id)
        {
            if (!await IsAdminAsync())
            {
                TempData["Error"] = "Access denied. Admins only.";
                return RedirectToAction("Index");
            }

            // Replace this line in Edit(int id):
            // var movie = await _movieRepo.GetAllAsync(id);

            // With this line:
            var movie = await _movieRepo.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        //  Admin Only: Handle Edit
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Movie movie)
        {
            if (!await IsAdminAsync()) return Forbid();

            var existing = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
            if (existing == null) return NotFound();

            // ✅ Use mapper to copy properties
            MovieMapper.UpdateMovieFromEdit(existing, movie);

            TempData["Success"] = "Movie updated.";
            return RedirectToAction("Index");
        }
        //  Admin Only: Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await IsAdminAsync()) return Forbid();

            var movie = StaticDb.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                StaticDb.Movies.Remove(movie);
                TempData["Success"] = "Movie deleted.";
            }

            return RedirectToAction("Index");
        }
    }
}