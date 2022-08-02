using System;
using Entities.Models;

namespace Contracts
{
    public interface ILifeAnamnesisRepository
    {
        void CreateLifeAnamnesisForPatient(int patientId, LifeAnamnesis lifeAnamnesis);
        LifeAnamnesis GetLifeAnamnesis(int patientId, int id, bool trackChanges);
        //void Update(int id, LifeAnamnesis LifeAnamnesis);
        void DeleteLifeAnamnesis(LifeAnamnesis lifeAnamnesis);

        //TODO update 

    }
}
