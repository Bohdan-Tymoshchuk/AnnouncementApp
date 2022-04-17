namespace AnnouncementApp.Dtos
{
    public class AnnouncementDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset AddedDate { get; set; }
    }
}
