using Lessons.Areas.ModelValidation.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lessons.Areas.ModelValidation.Models
{
    public class AppointmentVal
    {
        [Required]
        public string ClientName { get; set; }

        //[UIHint("Date")]
        [Required]
        [DataType(DataType.Date)]
        [Remote("ValidateDate", "Home")]
        public DateTime Date { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "The field must be checked.")]
        [MustBeTrue(ErrorMessage = "Zaznacz knefel")]
        public bool TermsAccepted { get; set; }

    }
}
