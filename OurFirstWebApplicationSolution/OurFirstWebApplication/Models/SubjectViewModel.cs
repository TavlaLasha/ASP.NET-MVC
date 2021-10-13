using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OurFirstWebApplication.Models
{
    public class SubjectViewModel
    {
        public int ID { get;  set; }

        [Display(Name = "საგნის სახელი")]
        [DataType(DataType.Text)]  
        public string Name { get; set; }

        [Display(Name = "საგნის აღწერა")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Display(Name = "საგნის კოდი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "საგნის კოდის მითითება სავალდებულოა"),MaxLength(10)]
        public string Code { get; set; }

        [Display(Name = "კრედიტები")]
        [Range(3, 18)]
        public int Credits { get; set; }

        [Display(Name = "საგნის საათები")]
        [Range(2, 3)]
        public int? Hours { get; set; }
        

    }
}