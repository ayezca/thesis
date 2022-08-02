using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetAllDoctors(bool trackChanges);
        Doctor GetDoctor(int id, bool trackChanges);
        void CreateDoctor(Doctor doctor);
        void AddDoctor(string uid);
        void DeleteDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
    }
}
