using AnnouncementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Announcement> Announcement { get; set; }
    }
}
