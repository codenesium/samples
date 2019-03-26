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

		Task<List<ApiJobCandidateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiJobCandidateServerResponseModel>> ByBusinessEntityID(int? businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>230c705b46b53e4d0e8ccd85ee2a7e29</Hash>
</Codenesium>*/