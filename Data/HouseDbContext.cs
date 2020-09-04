using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HouseVin.Data
{
    public class HouseDbContext:IdentityDbContext
    {
        public HouseDbContext(DbContextOptions<HouseDbContext> options) : base(options)
        {

        }

        public virtual DbSet<t_houseInfo> t_HouseInfo { get; set; }
    }
}
