using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IJobCandidateService
	{
		Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
			ApiJobCandidateRequestModel model);

		Task<UpdateResponse<ApiJobCandidateResponseModel>> Update(int jobCandidateID,
		                                                           ApiJobCandidateRequestModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		Task<ApiJobCandidateResponseModel> Get(int jobCandidateID);

		Task<List<ApiJobCandidateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiJobCandidateResponseModel>> ByBusinessEntityID(int? businessEntityID);
	}
}

/*<Codenesium>
    <Hash>ec2337459f4ecac7bb167d6af6c6f48b</Hash>
</Codenesium>*/