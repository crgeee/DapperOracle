using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        [StringLength(50, ErrorMessage = "String length must be less 50 Characters")]
        public string Name { get; set; }
        [StringLength(50, ErrorMessage = "String length must be less 50 Characters")]
        public string Description { get; set; }
        [StringLength(10, ErrorMessage = "String length must be less 10 Characters")]
        [Required]
        public string TimelineUnits { get; set; }
        public short? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        [StringLength(32, ErrorMessage = "String length must be less 32 Characters")]
        public string ModifiedBy { get; set; }
        [StringLength(32, ErrorMessage = "String length must be less 32 Characters")]
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}