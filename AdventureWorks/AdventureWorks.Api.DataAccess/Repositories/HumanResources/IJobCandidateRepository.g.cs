using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IJobCandidateRepository
	{
		Task<DTOJobCandidate> Create(DTOJobCandidate dto);

		Task Update(int jobCandidateID,
		            DTOJobCandidate dto);

		Task Delete(int jobCandidateID);

		Task<DTOJobCandidate> Get(int jobCandidateID);

		Task<List<DTOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<DTOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>dd90ceaf6158a6ac26965eec69816ea2</Hash>
</Codenesium>*/