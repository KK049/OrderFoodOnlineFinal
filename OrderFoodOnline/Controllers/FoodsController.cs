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
        public class FoodsController : Controller
        {
            private readonly OrderFoodOnlineContext _context;

            public FoodsController(OrderFoodOnlineContext context)
            {
                _context = context;
            }

            // GET: Foods
            public async Task<IActionResult> Index()
            {
            if (HttpContext.Session.GetString("Id") != null || HttpContext.Session.GetString("Name") != null)
            {
                var value = HttpContext.Session.GetString("Id");
                var name = HttpContext.Session.GetString("Name");
                var login = _context.Login.Where(x => x.Id == Convert.ToInt32(value)).FirstOrDefault();

                if (name == "Admin@gmail.com")
                {
                    return View(await _context.Foods.ToListAsync());
                    }
                    else
                    {
                    if (_context.Foods.ToList().Count == 0)
                    {
                        return RedirectToAction(nameof(FoodNotFound));
                    }
                    else
                    return RedirectToAction("Index", "Food");
                    }
            }
            else
                return RedirectToAction("UserLogin", "Logins");
            }

            // GET: Foods/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Foods = await _context.Foods
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Foods == null)
                {
                    return NotFound();
                }

                return View(Foods);
            }
        public IActionResult FoodNotFound()
        {
            return View();
        }
        
        // GET: Foods/Create
        public IActionResult Create()
            {
            return View();
            }

            // POST: Foods/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,FoodName,FoodType,NumberOfDishes,Rate,Location")] Foods Foods)
            {
                if (ModelState.IsValid)
                {
                    //Foods.UserId = Convert.ToInt32(HttpContext.Session.GetString("Id"));
                    _context.Add(Foods);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(Foods);
            }

            // GET: Foods/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Foods = await _context.Foods.FindAsync(id);
                if (Foods == null)
                {
                    return NotFound();
                }
                return View(Foods);
            }

            // POST: Foods/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for 
            // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("Id,FoodName,FoodType,NumberOfDishes,Rate,Location")] Foods Foods)
            {
                if (id != Foods.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(Foods);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FoodsExists(Foods.Id))
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
                return View(Foods);
            }

            // GET: Foods/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var Foods = await _context.Foods
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (Foods == null)
                {
                    return NotFound();
                }

                return View(Foods);
            }

            // POST: Foods/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                var Foods = await _context.Foods.FindAsync(id);
                _context.Foods.Remove(Foods);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool FoodsExists(int id)
            {
                return _context.Foods.Any(e => e.Id == id);
            }
        }
    }
