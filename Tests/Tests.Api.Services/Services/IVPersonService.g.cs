using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface IVPersonService
	{
		Task<CreateResponse<ApiVPersonServerResponseModel>> Create(
			ApiVPersonServerRequestModel model);

		Task<UpdateResponse<ApiVPersonServerResponseModel>> Update(int personId,
		                                                            ApiVPersonServerRequestModel model);

		Task<ActionResponse> Delete(int personId);

		Task<ApiVPersonServerResponseModel> Get(int personId);

		Task<List<ApiVPersonServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7af4d82cd2a8850b3a75fff2047953e9</Hash>
</Codenesium>*/