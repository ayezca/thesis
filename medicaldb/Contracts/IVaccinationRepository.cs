using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IVaccinationRepository
    {
        void CreateVaccination(Vaccination vaccination);
        IEnumerable<Vaccination> GetAllVaccinations(bool trackChanges);
        Vaccination GetVaccination(int id, bool trackChanges);
        void UpdateVaccination(Vaccination vaccination);
        //void DeleteVaccination(Vaccination vaccination);
    }
}
