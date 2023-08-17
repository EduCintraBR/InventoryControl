using AutoMapper;
using InventoryControl.Api.Data;
using InventoryControl.Api.Models.Dto;
using InventoryControl.Api.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly ICDbContext _db;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;

        public ProductService(ICDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }

        public async Task<ResponseDto> CreateProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> DeleteProductAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var product = await _db.Products.FirstOrDefaultAsync(a => a.Id == id);
                _response.Result = _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        public async Task<ResponseDto> GetAll()
        {
            try
            {
                var productsList = await _db.Products.ToListAsync();
                _response.Result = _mapper.Map<IList<ProductDto>>(productsList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        public async Task<ResponseDto> UpdateProductAsync()
        {
            throw new NotImplementedException();
        }
    }
}
