using HumanAndDoggo.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Model
{
    public class KennelCreate
    {
        [Required]
        public int KennelNumber { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public bool Occupied { get; set; }
        [Required]
        public int DoggoID { get; set; }
        public string DoggoName { get; set; }
    }
}
