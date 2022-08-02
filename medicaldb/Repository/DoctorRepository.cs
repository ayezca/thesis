using System;
using System.Collections.Generic;
using System.Linq;
using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class DoctorRepository : RepositoryBase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateDoctor(Doctor doctor)
        {
            Create(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctors(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.Id).ToList();

        public Doctor GetDoctor(int id, bool trackChanges) => FindByCondition(x => x.Id == id, trackChanges).SingleOrDefault();

        public void DeleteDoctor(Doctor doctor)
        {
            Delete(doctor);
        }

        public void AddDoctor(string uid) =>
            Create(new Doctor { UserId = uid });

        public void UpdateDoctor(Doctor doctor) =>
            Update(doctor);
    }
}
