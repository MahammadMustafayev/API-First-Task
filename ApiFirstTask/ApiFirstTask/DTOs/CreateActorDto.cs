using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiFirstTask.DTOs
{
    public class CreateActorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string InageUrl { get; set; }
    }
}
