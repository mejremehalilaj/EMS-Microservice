using System.ComponentModel.DataAnnotations;

namespace ReportService.API.Models
{
    public class Performance
    {
        [Required]
        public string Id { get; set; }

        public float PerformanceIndex { get; set; }

        [Required]
        public string StudentId { get; set; }

        public DateTime DateGenerated { get; set; }

    }
}
