﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class MovieModel
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DirectorId { get; set; }
        public int GenreId { get; set; }
        public int Year { get; set; }
    }
}
