using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrderFoodOnline.Models;

namespace OrderFoodOnline.Data
{
    public class OrderFoodOnlineContext : DbContext
    {
        public OrderFoodOnlineContext (DbContextOptions<OrderFoodOnlineContext> options)
            : base(options)
        {
        }
        public DbSet<Foods> Foods { get; set; }
        public DbSet<FoodOrder> FoodOrder { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Login> Login { get; set; }
    }
}
