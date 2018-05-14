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

		POCOJobCandidate Get(int jobCandidateID);

		List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOJobCandidate> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>0156a27f7ab24cea3998852875232070</Hash>
</Codenesium>*/