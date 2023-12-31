﻿using AutoMapper;
using InventoryControl.Api.Data;
using InventoryControl.Api.Models;
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

        public async Task<ResponseDto> CreateProductAsync(ProductDto productDto)
        {
            try
            {
                var productToAdd = _mapper.Map<Product>(productDto);
                
                await _db.Products.AddAsync(productToAdd);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(productToAdd);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        public async Task<ResponseDto> DeleteProductAsync(int id)
        {
            try
            {
                var productToDelete = await _db.Products.FirstOrDefaultAsync(a => a.Id == id);
                if (productToDelete == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "Id do produto inexistente.";
                    return _response;
                }

                _db.Products.Remove(productToDelete);
                await _db.SaveChangesAsync();

                _response.Message = "Produto deletado com sucesso.";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
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

        public async Task<ResponseDto> UpdateProductAsync(ProductDto productDto)
        {
            try
            {
                var productToUpdate = await _db.Products.FirstOrDefaultAsync(a => a.Id == productDto.Id);
                if(productToUpdate == null) 
                {
                    _response.IsSuccess = false;
                    _response.Message = "Id do produto inexistente.";
                    return _response;
                }

                productToUpdate.Name = productDto.Name;
                productToUpdate.Price = productDto.Price;

                _db.Update(productToUpdate);
                await _db.SaveChangesAsync();

                _response.Result = _mapper.Map<ProductDto>(productToUpdate);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
