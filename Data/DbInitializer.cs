using System;
using System.Linq;

namespace HouseVin.Data
{
    public static class DbInitializer
    {
        public static void Initialize(HouseDbContext context)
        {
            context.Database.EnsureCreated();

            
        }
    }
}