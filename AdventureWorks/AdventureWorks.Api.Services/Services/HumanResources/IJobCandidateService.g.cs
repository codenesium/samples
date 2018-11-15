using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IJobCandidateService
	{
		Task<CreateResponse<ApiJobCandidateServerResponseModel>> Create(
			ApiJobCandidateServerRequestModel model);

		Task<UpdateResponse<ApiJobCandidateServerResponseModel>> Update(int jobCandidateID,
		                                                                 ApiJobCandidateServerRequestModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		Task<ApiJobCandidateServerResponseModel> Get(int jobCandidateID);

		Task<List<ApiJobCandidateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiJobCandidateServerResponseModel>> ByBusinessEntityID(int? businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>acc370bbd84dcf6593385bcc9d8ceca9</Hash>
</Codenesium>*/