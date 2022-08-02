using System;
namespace Entities.DataTransferObjects
{
    public class DoctorForCreationDto
    {
        public int Id { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int SpecialtyId { get; set; }

    }
}
