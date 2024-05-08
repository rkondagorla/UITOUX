using System.ComponentModel.DataAnnotations;

namespace UITOUX.Web.Service.Models
{
    public class Category
    {
        [Key]
        public long CategoryId { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public long? ParentCategoryId { get; set; }

        public long? CreatedBy { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTimeOffset? ModifiedOn { get; set; }

        public bool IsActive { get; set; }

    }
}
