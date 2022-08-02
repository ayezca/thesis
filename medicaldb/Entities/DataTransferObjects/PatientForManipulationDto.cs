using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class PatientForManipulationDto
    {
        [Required(ErrorMessage = "Patient name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Name is 30 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Patient lastname is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Lastname is 40 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Patient patronymic is a required field.")]
        [MaxLength(40, ErrorMessage = "Maximum length for the Patronymic is 40 characters.")]
         public string Patronymic { get; set; }

         [Required(ErrorMessage = "Patient birth date is a required field.")]
         public DateTime BirthDate { get; set; }

         [Required(ErrorMessage = "Patient gender is a required field.")]
         public bool Sex { get; set; }

         [Required(ErrorMessage = "Patient phone number is a required field.")]
         [MaxLength(30, ErrorMessage = "Maximum length for the PhoneNumber is 30 characters.")]
         public string PhoneNumber { get; set; }

         public string Email { get; set; }
         public string Address { get; set; }

         public IEnumerable<ComplainForCreationDto> Complains { get; set; }
    }
}
