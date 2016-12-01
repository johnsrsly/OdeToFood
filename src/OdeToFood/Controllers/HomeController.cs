using Microsoft.AspNetCore.Mvc;
using OdeToFood.Entities;
using OdeToFood.Services;
using OdeToFood.ViewModels;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IResturantData _resturandData;

        public HomeController(IResturantData resturantData, IGreeter greeter)
        {
            _resturandData = resturantData;
            _greeter = greeter;
        }
        public IActionResult index()
        {
            var model = new HomePageViewModel();
            model.Resturants = _resturandData.GetAll();
            model.CurrentMessage = _greeter.GetGreeting();

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _resturandData.Get(id);
            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResturantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
            var newResturant = new Resturant();
            newResturant.Cuisine = model.Cuisine;
            newResturant.Name = model.Name;

            newResturant = _resturandData.Add(newResturant);

            return RedirectToAction("Details", new { id = newResturant.Id });

            }
            return View();
        }
    }
}
