using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IComplainRepository
    {
        void CreateComplainForPatient(int patientId, Complain complain);
        IEnumerable<Complain> GetAllComplains(int patientId, bool trackChanges);
        Complain GetComplain(int patientId, int id, bool trackChanges);
        void UpdateComplain(Complain complain);
        void DeleteComplain(Complain complain);

    }
}
