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
		Task<CreateResponse<int>> Create(
			JobCandidateModel model);

		Task<ActionResponse> Update(int jobCandidateID,
		                            JobCandidateModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		POCOJobCandidate Get(int jobCandidateID);

		List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>baceeefa7d2249638dd024cdc00ea2d6</Hash>
</Codenesium>*/