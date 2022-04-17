using AnnouncementApp.Abstractions;
using AnnouncementApp.Data;
using AnnouncementApp.Dtos;
using AnnouncementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementApp.Repositories
{
    public class AnnouncementRepository : BaseRepository<Announcement>, IAnnouncementRepository
    {
        private readonly DataContext _context;
        public AnnouncementRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Announcement>> FindSimilarAnnouncements(Announcement selectedAnnouncement)
        {
            var splitedTitle = selectedAnnouncement.Title.Split(" ");
            var splitedDescription = selectedAnnouncement.Description.Split(" ");

            var result = await _context.Announcement.Where(x => splitedTitle.Contains(x.Title) && splitedDescription.Contains(x.Description) && x.Id != selectedAnnouncement.Id).ToListAsync();

            return result;
        }
    }
}
