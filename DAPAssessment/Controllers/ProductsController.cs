using AutoMapper;
using DAPAssessment.Models;
using DAPAssessment.Models.Dto;
using DAPAssessment.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DAPAssessment.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _repository.CreateProductAsync(product);
            var createdProductDto = _mapper.Map<ProductDTO>(createdProduct);
            return CreatedAtAction(nameof(GetProductById), new { id = createdProductDto.Id }, createdProductDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _repository.GetAllProductsAsync();
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            var productDto = _mapper.Map<ProductDTO>(product);
            return Ok(productDto);
        }
    }

}
