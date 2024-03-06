using Microsoft.AspNetCore.Mvc;
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
        
        // GET: api/<ReviewsController>
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.ToList();
            return Ok(reviews);
        }

        // GET api/<ReviewsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var review = _context.Reviews.Find(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST api/<ReviewsController>
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return StatusCode(201, review);
        }

        // PUT api/<ReviewsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review review)
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
