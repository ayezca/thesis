using System;
using System.Collections.Generic;

namespace Entities.DataTransferObjects
{
    public class ProfileDto : DoctorDto
    {
        public ProfileDto()
        {
            Roles = new List<string>();
        }

        public List<string> Roles { get; set; }
    }
}
