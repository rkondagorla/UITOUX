using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UITOUX.Web.Service.Models
{
    public class BannerItem
    {
        [Key]
        public long BannerItemId { get; set; }
        public long? BannerId { get; set; }
        public long? CategoryId { get; set; }
        public string? URL { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public bool IsActive { get; set; }

    }
}
