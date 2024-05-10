using System.ComponentModel.DataAnnotations;

namespace UITOUX.Web.Service.Models
{
    public class Model
    {
        [Key]
        public long ModelId { get; set; }
        public long? BrandId { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public long? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public bool IsActive { get; set; }
        public virtual Brand brand { get; set; }
    }
}
