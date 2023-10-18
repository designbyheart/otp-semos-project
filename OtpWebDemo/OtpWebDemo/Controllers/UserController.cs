using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtpWebDemo.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OtpWebDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly HttpClient _httpClient;
        public UserController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7184/") };
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User");
                if (response.IsSuccessStatusCode)
                {
                    var userDetails = await response.Content.ReadFromJsonAsync<IEnumerable<User>>();
                    return View(userDetails);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var userDetails = await response.Content.ReadFromJsonAsync<User>();
                    return View(userDetails);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Password,Phone,BirthDate")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var response = await _httpClient.PostAsJsonAsync("api/user", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = user.Id });
            }

            ModelState.AddModelError(string.Empty, "Failed to create user.");
            return View(user);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var userDetails = await response.Content.ReadFromJsonAsync<User>();
                    return View(userDetails);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var response = await _httpClient.PutAsJsonAsync($"api/user/{user.Id}", user);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Details", new { id = user.Id });
            }

            ModelState.AddModelError(string.Empty, "Failed to update user.");
            return View(user);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/User/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var userDetails = await response.Content.ReadFromJsonAsync<User>();
                    return View(userDetails);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: User/DeleteUser/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/user/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");  // Redirect to an Index action or any other action
            }

            ModelState.AddModelError(string.Empty, "Failed to delete user.");
            return RedirectToAction("Details", new { id = id });  // Redirect back to the User action in case of failure
        }
    }
}
