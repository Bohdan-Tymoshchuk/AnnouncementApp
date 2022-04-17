using AnnouncementApp.Abstractions;
using AnnouncementApp.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementApp.Controllers
{
    [Route("api/announcement")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<AnnouncementDto> Create(AnnouncementForAddDto announcement)
        {
            return await _announcementService.AddAsync(announcement);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<AnnouncementDto> Edit(AnnouncementDto announcement)
        {
            return await _announcementService.EditAsync(announcement);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task Delete(int id)
        {
            await _announcementService.DeleteAsync(id);
        }

        [HttpGet]
        public async Task<List<AnnouncementDto>> GetAll()
        {
            return await _announcementService.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<AnnouncementDetailsDto> GetById(int id)
        {
            return await _announcementService.GetAnnouncementDetails(id);
        }


    }
}
