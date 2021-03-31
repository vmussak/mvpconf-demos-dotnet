using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvpConfDemos.MvcCore.Models;
using System;

namespace MvpConfDemos.MvcCore.Database
{
    public class MvpConfContext : DbContext
    {
        public MvpConfContext(DbContextOptions<MvpConfContext> options) : base(options)
        {

        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
