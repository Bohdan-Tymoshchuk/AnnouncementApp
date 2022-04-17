using AnnouncementApp.Dtos;
using AnnouncementApp.Models;

namespace AnnouncementApp.Abstractions
{
    public interface IAnnouncementService
    {
        public Task<List<AnnouncementDto>> GetAll();

        public Task<AnnouncementDetailsDto> GetAnnouncementDetails(int id);

        public Task<AnnouncementDto> AddAsync(AnnouncementForAddDto announcementDto);

        public Task<AnnouncementDto> EditAsync(AnnouncementDto announcementDto);

        public Task DeleteAsync(int id);
    }
}
