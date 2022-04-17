namespace AnnouncementApp.Dtos
{
    public class AnnouncementDetailsDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset AddedDate { get; set; }

        public List<AnnouncementDto> Announcements { get; set; }
    }
}
