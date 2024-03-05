﻿namespace ProjectReviewsWebAPI.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        //need to use [ForeignKey] attribute
    }
}
