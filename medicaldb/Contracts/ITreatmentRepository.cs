using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ITreatmentRepository
    {
        void CreateTreatment(Treatment treatment);
        IEnumerable<Treatment> GetAllTreatments(bool trackChanges);
        Treatment GetTreatment(int id, bool trackChanges);
        void UpdateTreatment(Treatment treatment);
        //void DeleteTreatment(Treatment treatment);
    }
}
