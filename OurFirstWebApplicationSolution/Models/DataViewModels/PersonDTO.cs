using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataViewModels
{
    public class PersonDTO
    {
        [Display(Name = "სახელი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "სახელის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "სახელი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string FirstName { get; set; }

        [Display(Name = "გვარი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "გვარის მითითება სავალდებულოა"), MaxLength(50, ErrorMessage = "გვარი არ უნდა აღემატებოდეს 50 სიმბოლოს")]
        public string LastName { get; set; }

        [Display(Name = "პირადი ნომერი")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "პირადი ნომრის მითითება სავალდებულოა"), MaxLength(11, ErrorMessage = "პირადი ნომერი არ უნდა აღემატებოდეს 11 სიმბოლოს")]
        public string PN { get; set; }

        [Display(Name = "ელ-ფოსტა")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "შეყვანილი ელ-ფოსტია არავალიდურია")]
        public string Email { get; set; }

        [Display(Name = "დაბადების თარიღი")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "ელ-ფოსტის მითითება სავალდებულოა")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "ფოტო")]
        [DataType(DataType.Text)]
        public byte[] Photo { get; set; }
    }
}
