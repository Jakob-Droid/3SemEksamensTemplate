using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLibrary;

namespace RestServiceInMemory.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options){}


        public DbSet<Car> CarModel { get; set; }
    }
}
