using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanAndDoggo.Data
{
    public enum Size
    {
        Small = 1, Medium, Large, XLarge
    }
    public class Kennel
    {
        [Key]
        public int KennelID { get; set; }
        [Required]
        public int KennelNumber { get; set; }
        [Required]
        public Size Size { get; set; }
        [Required]
        public bool Occupied { get; set; }
        [Required]
        public int DoggoID { get; set; }
        [Required]
        public string DoggoName { get; set; }
        [Required]
        public int HumanID { get; set; }
        [Required]
        public string FullName { get; set; }
    }
}
