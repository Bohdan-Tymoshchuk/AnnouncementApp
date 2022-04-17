using System.ComponentModel.DataAnnotations.Schema;

namespace AnnouncementApp.Models
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}