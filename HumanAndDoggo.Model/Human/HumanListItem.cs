using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class HumanListItem
    {
        public int HumanID { get; set; }
        [Display(Name = "First and Last Name")]
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> DoggoName { get; set; }
    }
}
