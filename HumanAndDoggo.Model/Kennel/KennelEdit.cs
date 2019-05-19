using HumanAndDoggo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class KennelEdit
    {
        public int KennelID { get; set; }
        public int KennelNumber { get; set; }
        public bool Occupied { get; set; }
        public int DoggoID { get; set; }
        public string DoggoName { get; set; }
        public string FullName { get; set; }
        public Size Size { get; set; }
    }
}
