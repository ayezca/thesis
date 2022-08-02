using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface IExaminationRepository
    {
        IEnumerable<Examination> GetAllExaminations(bool trackChanges);
        Examination GetExamination(int id, bool trackChanges);
        void CreateExamination(Examination examination);
        void DeleteExamination(Examination examination);
        void UpdateExamination(Examination examination);
    }
}
