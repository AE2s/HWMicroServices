using System;
using System.Collections.Generic;

namespace HelloWorldMicroServices.Domain.Models
{
    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CreatedOn { get; }

        public DateTime DeletedOn { get; set; }

        public Author Author { get; set; }

        public List<Tag> Tags { get; set; }

        public Article()
        {
            CreatedOn = DateTime.Now;
            Tags = new List<Tag>();
        }
    }
}