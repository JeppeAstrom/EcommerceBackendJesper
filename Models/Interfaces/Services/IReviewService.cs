using EcommerceBackend.Models.Dtos.Reviews;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Models.Interfaces.Services
{
    public interface IReviewService : IBaseService<ReviewEntity>
    {
        public Task<IActionResult> CreateAsync(ReviewSchema schema, string id);
    }
}
