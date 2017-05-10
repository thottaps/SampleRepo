using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusinessAccessLayer
{
    public class Expences
    {
        public int ExpenceID { get; set; }
        [Required]
        public string ExpenceType { get; set; }
        [Required]
        public decimal ExpenceAmt { get; set; }
        [Required]
        public DateTime ExpenceDate { get; set; }
        [Required]
        public string ExpenceDescription { get; set; }
        
    }

    public class ExpencesType
    {
        public int ExpenceTypeID { get; set; }
        public string ExpenceType { get; set; }

    }
}
