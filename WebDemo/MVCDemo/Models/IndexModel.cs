using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCDemo.Models
{
    public class IndexModel
    {
        [Required]
        [StringLength(50)]
        [Range(1,100)]
        [Compare(nameof(Num2))]
        [EmailAddress(ErrorMessage = "error")]
        [RegularExpression(@"")]
        [Phone]
        public int Num1 { get; set; }
        public int Num2 { get; set; }
        public int Result { get; set; }
    }
}