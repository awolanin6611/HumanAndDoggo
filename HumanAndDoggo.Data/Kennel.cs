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
        Small, Medium, Large, XLarge
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
        
        public int DoggoID { get; set; }
        
        public string DoggoName { get; set; }

        
        public string FullName { get; set; }

        public virtual Human Human { get; set; }
        public virtual Doggo Doggo { get; set; }
    }
}
