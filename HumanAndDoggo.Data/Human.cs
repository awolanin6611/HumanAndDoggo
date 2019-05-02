using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Data
{
    public class Human
    {
        [Key]
        public int HumanID { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> DoggoNames { get; set; }

    }
}
