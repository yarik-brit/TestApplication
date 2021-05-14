using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DirectorModel
    {
        [Key]
        public int DirectorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
