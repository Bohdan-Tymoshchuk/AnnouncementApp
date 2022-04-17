using AnnouncementApp.Abstractions;
using AnnouncementApp.Dtos;
using AnnouncementApp.Models;

namespace AnnouncementApp.Services
{
    public class AnnouncementService : IAnnouncementService 
    {

        private readonly IAnnouncementRepository _announcementRepository;

        public AnnouncementService(IAnnouncementRepository announcementRepository)
        {
            _announcementRepository = announcementRepository;
        }

        public async Task<AnnouncementDto> AddAsync(AnnouncementForAddDto announcementDto)
        {
            var announcement = new Announcement
            {
                Title = announcementDto.Title,
                Description = announcementDto.Description,
                AddedDate = DateTimeOffset.UtcNow
            };

            var createdAnnouncement = await _announcementRepository.CreateAsync(announcement);

            if (createdAnnouncement is null)
                return null;

            return new AnnouncementDto
            {
                Id = createdAnnouncement.Id,
                Title = createdAnnouncement.Title,
                Description = createdAnnouncement.Description,
                AddedDate = createdAnnouncement.AddedDate
            };
        }

        public async Task DeleteAsync(int id)
        {
            var announcement = await _announcementRepository.GetByIdAsync(id);

            if (announcement is null)
                throw new InvalidOperationException();

            await _announcementRepository.DeleteAsync(announcement);
        }

        public async Task<AnnouncementDto> EditAsync(AnnouncementDto announcementDto)
        {
            var editAnnouncement = await _announcementRepository.GetByIdAsync(announcementDto.Id);

            if (editAnnouncement is null)
                throw new InvalidOperationException();

            editAnnouncement.Description = announcementDto.Description;
                editAnnouncement.Title = announcementDto.Title;

            await _announcementRepository.UpdateAsync(editAnnouncement);

            return announcementDto;
        }

        public async Task<List<AnnouncementDto>> GetAll()
        {
            var allAnnouncements = await _announcementRepository.GetAllAsync();
            var announcementDto = new List<AnnouncementDto>();

            allAnnouncements.ForEach(x => 
            announcementDto.Add( new AnnouncementDto 
            { 
                AddedDate = x.AddedDate,
                Description = x.Description,
                Title = x.Title,
                Id = x.Id
            }));

            return announcementDto;
        }

        public async Task<AnnouncementDetailsDto> GetAnnouncementDetails(int id)
        {
            var findedAnnouncement = await _announcementRepository.GetByIdAsync(id);

            if (findedAnnouncement is null)
                throw new InvalidOperationException();

            var announcementSelected = new AnnouncementDetailsDto
            {
                Id = findedAnnouncement.Id,
                Description = findedAnnouncement.Description,
                Title = findedAnnouncement.Title,
                AddedDate = findedAnnouncement.AddedDate
            };

            var topSimilarAnnouncements = await _announcementRepository.FindSimilarAnnouncements(findedAnnouncement);
            announcementSelected.Announcements = topSimilarAnnouncements.Take(3).Select(x => new AnnouncementDto { Id = x.Id,  AddedDate = x.AddedDate, Description = x.Description, Title = x.Title}).ToList();

            return announcementSelected;
        }
    }
}
