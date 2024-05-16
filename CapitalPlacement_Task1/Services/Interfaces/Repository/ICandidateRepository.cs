using CapitalPlacement_Task1.Domain;

namespace CapitalPlacement_Task1.Services.Interfaces.Repository;

public interface ICandidateRepository
{
    Task<Candidate> Create(Candidate candidate);
    Task<Candidate> Update(Candidate candidate);
    Task<Candidate> GetById(string id);
    Task<bool> Delete(string id);
}
