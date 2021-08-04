using OrderFoodOnline.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFoodOnline.Controllers
{
    public class OrderedFoodsController : Controller
    {
        private readonly OrderFoodOnlineContext _context;

        public OrderedFoodsController(OrderFoodOnlineContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("Id") != null)
            {
                var value = HttpContext.Session.GetString("Id");

                return View(await _context.FoodOrder.Where(x => x.UserId == Convert.ToInt32(value)).ToListAsync());
            }
            else
                return RedirectToAction("UserLogin", "Logins");
        }
    }
}
