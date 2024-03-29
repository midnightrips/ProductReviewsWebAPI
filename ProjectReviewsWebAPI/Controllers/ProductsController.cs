﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ProductReviewsWebAPI.DataTransferObjects;
using ProjectReviewsWebAPI.Data;
using ProjectReviewsWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReviewsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult GetProduct()
        {
            var products = _context.Products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Reviews = p.Reviews.Select(r => new ReviewDTO
                {
                    Id = r.Id,
                    Text = r.Text,
                    Rating = r.Rating,
                }).ToList(),
            }).ToList();
            
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return StatusCode(201, product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            var existingProduct = _context.Products.Where(p => p.Id == id).SingleOrDefault();

            if (existingProduct == null)
            {
                return NotFound();
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;

            product = existingProduct;

            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Where(p => p.Id == id).SingleOrDefault();
            _context.Products.Remove(product);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
