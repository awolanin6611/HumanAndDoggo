using HumanAndDoggo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class DoggoCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than two characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field")]
        public string Name { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public int HumanID { get; set; }
        public bool DoggoFriendly { get; set; }
        public bool PeopleFriendly { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter more than two characters")]
        [MaxLength(1080, ErrorMessage = "There are too many characters in this field")]
        public string SpecialNeeds { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }
    }
}
