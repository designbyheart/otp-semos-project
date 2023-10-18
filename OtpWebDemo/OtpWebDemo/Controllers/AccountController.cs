using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtpWebDemo.Models;

namespace OtpWebDemo.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _httpClient;

        public AccountController()
        {
            _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7184/") };
        }

        // GET: AccountController
        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Account");
                if (response.IsSuccessStatusCode)
                {
                    var accounts = await response.Content.ReadFromJsonAsync<IEnumerable<Account>>();
                    return View(accounts);
                }

                ModelState.AddModelError(string.Empty, "Failed to retrieve user details.");
                return View();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CardType,MonthlyFee,EBank,UserId")] Account account)
        {
            if (!ModelState.IsValid)
            {
                return View(account);
            }

            var response = await _httpClient.PostAsJsonAsync("api/account", account);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "Failed to create account.");
            return View(account);
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
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

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
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
