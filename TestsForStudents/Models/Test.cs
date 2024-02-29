﻿using System.ComponentModel.DataAnnotations;

namespace TestsForStudents.Models
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
