using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class GenreModel
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
