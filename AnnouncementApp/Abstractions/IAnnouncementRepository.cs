using AnnouncementApp.Dtos;
using AnnouncementApp.Models;

namespace AnnouncementApp.Abstractions
{
    public interface IAnnouncementRepository : IBaseRepository<Announcement>
    {
        public Task<List<Announcement>> FindSimilarAnnouncements(Announcement announcementDto);
    }
}
