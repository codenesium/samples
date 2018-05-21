using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOJobCandidate
	{
		Task<CreateResponse<POCOJobCandidate>> Create(
			ApiJobCandidateModel model);

		Task<ActionResponse> Update(int jobCandidateID,
		                            ApiJobCandidateModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		Task<POCOJobCandidate> Get(int jobCandidateID);

		Task<List<POCOJobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<POCOJobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>d0b18a6c16fcc96512f69fb04136c688</Hash>
</Codenesium>*/