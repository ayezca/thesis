using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IDiseaseAnamnesisRepository
    {
        void CreateDiseaseAnamnesisForPatient(int patientId, DiseaseAnamnesis diseaseAnamnesis);
        IEnumerable<DiseaseAnamnesis> GetAllDiseaseAnamneses(int patientId, bool trackChanges);
        DiseaseAnamnesis GetDiseaseAnamnesis(int patientId, int id, bool trackChanges);
        //void Update(int id, DiseaseAnamnesis diseaseAnamnesis);
        void DeleteDiseaseAnamnesis(DiseaseAnamnesis diseaseAnamnesis);

        //TODO update 
    }
}
