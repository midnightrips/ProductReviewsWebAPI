using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectReviewsWebAPI.Data;
using ProjectReviewsWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductReviewsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: api/Reviews
        [HttpGet]
        public IActionResult GetReview()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/Reviews/5
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var review = _context.Reviews.Include(r => r.Product).FirstOrDefault(r => r.Id ==id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST api/Reviews
        [HttpPost]
        public IActionResult PostReview(Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

        // PUT api/Reviews/5
        [HttpPut("{id}")]
        public IActionResult PutReview(int id, Review review)
        {
            var existingReview = _context.Reviews.Where(r => r.Id == id).SingleOrDefault();

            if (existingReview == null)
            {
                return NotFound();
            }

            existingReview.Text = review.Text;
            existingReview.Rating = review.Rating;

            _context.SaveChanges();
            return Ok(existingReview);
        }

        // DELETE api/<ReviewsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Where(r => r.Id == id).SingleOrDefault();
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
