using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFirstTask.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsName { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
