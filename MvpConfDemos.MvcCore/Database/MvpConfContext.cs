using Microsoft.EntityFrameworkCore;
using MvpConfDemos.MvcCore.Models;

namespace MvpConfDemos.MvcCore.Database
{
    public class MvpConfContext : DbContext
    {
        public MvpConfContext(DbContextOptions<MvpConfContext> options) : base(options)
        {

        }

        public DbSet<ClienteMvp> ClienteMvp { get; set; }
    }
}
