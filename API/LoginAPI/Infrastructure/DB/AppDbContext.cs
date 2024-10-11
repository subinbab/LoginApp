using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DB
{
  using Core.AbstractModels.Login;
  using Core.AbstractModels.Project;
  using Core.AbstractModels.Register;
  using Core.AbstractModels.User;
  using Microsoft.AspNetCore.Identity;
  using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore;

  public class AppDbContext : IdentityDbContext<IdentityUser>
  {
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserLogin> Users { get; set; }
    public DbSet<Register> register { get; set; }
    public DbSet<ProjectModel> projectModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      base.OnModelCreating(modelBuilder);
    }

  }

}
