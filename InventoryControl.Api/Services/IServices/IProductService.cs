using InventoryControl.Api.Models.Dto;

namespace InventoryControl.Api.Services.IServices
{
    public interface IProductService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> Get(int id);
        Task<ResponseDto> CreateProductAsync();
        Task<ResponseDto> UpdateProductAsync();
        Task<ResponseDto> DeleteProductAsync();
    }
}
