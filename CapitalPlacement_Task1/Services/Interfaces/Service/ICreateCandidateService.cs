using CapitalPlacement_Task1.Controllers.Requests;
using CapitalPlacement_Task1.Domain;

namespace CapitalPlacement_Task1.Services.Interfaces.Service;

public interface ICreateCandidateService
{
    Task<Candidate> CreateCandidate(CreateCandidateRequest candidateRequest);
}
