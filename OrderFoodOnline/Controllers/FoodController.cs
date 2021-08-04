using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.Data;
using OrderFoodOnline.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OrderFoodOnline.Controllers
{
    public class FoodController : Controller
    {
        private readonly OrderFoodOnlineContext _context;

        public FoodController(OrderFoodOnlineContext context)
        {
            _context = context;
        }

        // GET: Foods
        public async Task<IActionResult> Index()
        {
          return View(await _context.Foods.ToListAsync());
        }
        public async Task<IActionResult> AddFood(int? id)
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                FoodOrder buyBook = new FoodOrder();
                var book = _context.Foods.Where(x => x.Id == id).FirstOrDefault();
                buyBook.FoodName = book.FoodName;
                buyBook.FoodType = book.FoodType;
                buyBook.NumberOfDishes = book.NumberOfDishes;
                buyBook.Rate = book.Rate;
                buyBook.UserId = Convert.ToInt32(value);
                _context.Add(buyBook);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "OrderedFoods");
            }
            else
                return RedirectToAction("UserLogin", "Logins");
        }

    }
}
