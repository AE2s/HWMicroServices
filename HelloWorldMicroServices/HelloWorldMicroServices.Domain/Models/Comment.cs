using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldMicroServices.Domain.Models
{
    public class Comment
    {
        public string Name { get; set; }
        public DateTime CreatedOn { get; }
        public string Value { get; set; }

        public Comment()
        {
            CreatedOn=DateTime.Now;
        }
    }
}
