using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Data
{
    public class Doggo
    {
        [Key]
        public int DoggoID { get; set; }
        public string DoggoName { get; set; }
        public string Breed { get; set; }
        public Size Size { get; set; }
        [Display(Name = "Person")]
        public int HumanID { get; set; }
        [Display(Name = "Doggo Friendly?")]
        public bool DoggoFriendly { get; set; }
        [Display(Name = "People Friendly")]
        public bool PeopleFriendly { get; set; }
        [Display(Name = "Special Needs")]
        public string SpecialNeeds { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }

        public virtual Human Human { get; set; }
    }
}
