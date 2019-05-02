using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class HumanCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter your Name.")]
        [MaxLength(128)]
        public string FullName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please Enter your Address.")]
        [MaxLength(128)]
        public string Address { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please Enter your phone with area code.")]
        [MaxLength(10)]
        public string Phone { get; set; }

        [MinLength(2, ErrorMessage = "Please Enter your email.")]
        [MaxLength(128)]
        public string Email { get; set; }
    }
}
