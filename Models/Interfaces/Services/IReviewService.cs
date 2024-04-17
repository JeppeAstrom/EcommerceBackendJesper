using EcommerceBackend.Models.Schemas;
using examensarbete_backend.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceBackend.Models.Interfaces.Services
{
    public interface IReviewService : IBaseService<ReviewEntity>
    {
        public Task<IActionResult> CreateAsync(ReviewSchema schema, string id);
    }
}
