using InventoryControl.Api.Models.Dto;

namespace InventoryControl.Api.Services.IServices
{
    public interface IProductService
    {
        Task<ResponseDto> GetAll();
        Task<ResponseDto> Get(int id);
        Task<ResponseDto> CreateProductAsync(ProductDto productDto);
        Task<ResponseDto> UpdateProductAsync(int id, ProductDto productDto);
        Task<ResponseDto> DeleteProductAsync(int id);
    }
}
