using HumanAndDoggo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class DoggoListItem
    {
        public int DoggoID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public Size Size { get; set; }
        public string HumanID { get; set; }
        public bool DoggoFriendly { get; set; }
        public bool PeopleFriendly { get; set; }
        public string SpecialNeeds { get; set; }
        public string Age { get; set; }
        public string Image { get; set; }
    }
}
