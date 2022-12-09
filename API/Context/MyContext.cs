using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using System.Data;

namespace API.Context
{
    public partial class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> tb_m_Users{ get; set; }
        public DbSet<Role> tb_m_Roles { get; set; }
        public DbSet<Kosts> tb_tr_Kosts { get; set; }
        public DbSet<PemilikKost> tb_m_PemilikKost { get; set; }
    }

}
