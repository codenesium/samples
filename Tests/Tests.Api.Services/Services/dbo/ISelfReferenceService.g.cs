using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ISelfReferenceService
	{
		Task<CreateResponse<ApiSelfReferenceServerResponseModel>> Create(
			ApiSelfReferenceServerRequestModel model);

		Task<UpdateResponse<ApiSelfReferenceServerResponseModel>> Update(int id,
		                                                                  ApiSelfReferenceServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiSelfReferenceServerResponseModel> Get(int id);

		Task<List<ApiSelfReferenceServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>0c51aaaa4999453f128eb50290886146</Hash>
</Codenesium>*/