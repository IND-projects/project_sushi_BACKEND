using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSushi.Database.Entities;

namespace ProjectSushi.Database.ProjectSushiDbContext;

public class ProjectSushiContext : DbContext
{
    //public ProjectSushiContext()
    //{
    //}

    public ProjectSushiContext(DbContextOptions<ProjectSushiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Roll> Rolls { get; set; }
    public virtual DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relations Configuring
        //Roll-Category
        modelBuilder.Entity<Roll>()
            .HasOne(c => c.Category)
            .WithMany(r => r.Rolls)
            .HasForeignKey(r => r.CategoryId);
    }
}