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
		Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
			ApiJobCandidateRequestModel model);

		Task<ActionResponse> Update(int jobCandidateID,
		                            ApiJobCandidateRequestModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		Task<ApiJobCandidateResponseModel> Get(int jobCandidateID);

		Task<List<ApiJobCandidateResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<ApiJobCandidateResponseModel>> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>811e126d22268af35ed188c0a9c72654</Hash>
</Codenesium>*/