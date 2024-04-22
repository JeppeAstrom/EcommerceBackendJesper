using examensarbete_backend.Models.Entities;

namespace examensarbete_backend.Models.Dtos.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }    
        public Guid ParentCategoryId { get; set; }
        public virtual List<CategoryEntity> ChildCategories { get; set; } = new List<CategoryEntity>();
    }

}
