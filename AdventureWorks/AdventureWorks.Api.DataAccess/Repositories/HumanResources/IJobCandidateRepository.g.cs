using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IJobCandidateRepository
	{
		Task<POCOJobCandidate> Create(ApiJobCandidateModel model);

		Task Update(int jobCandidateID,
		            ApiJobCandidateModel model);

		Task Delete(int jobCandidateID);

		Task<POCOJobCandidate> Get(int jobCandidateID);

		Task<List<POCOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>bf49dabf6d4016bbd6945745e1ca5e27</Hash>
</Codenesium>*/