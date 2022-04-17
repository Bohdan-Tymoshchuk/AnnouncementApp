namespace AnnouncementApp.Models
{
    public class Announcement : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTimeOffset AddedDate { get; set; }
    }
}
