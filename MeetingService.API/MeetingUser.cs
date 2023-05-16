using System.ComponentModel.DataAnnotations;

namespace MeetingService.API
{
    public class MeetingUser
    {
        //nese sbon kontrollo qet key se kom shtu von hjeke
        [Key]
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
