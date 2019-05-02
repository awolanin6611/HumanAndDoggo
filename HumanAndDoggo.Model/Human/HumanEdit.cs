using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class HumanEdit
    {
        public int HumanID { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<string> DoggoNames { get; set; }
    }
}
