using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface ICallStatuService
	{
		Task<CreateResponse<ApiCallStatuServerResponseModel>> Create(
			ApiCallStatuServerRequestModel model);

		Task<UpdateResponse<ApiCallStatuServerResponseModel>> Update(int id,
		                                                              ApiCallStatuServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiCallStatuServerResponseModel> Get(int id);

		Task<List<ApiCallStatuServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiCallServerResponseModel>> CallsByCallStatusId(int callStatusId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>998db1120cf8c7834c1e1f16f16cf7ad</Hash>
</Codenesium>*/