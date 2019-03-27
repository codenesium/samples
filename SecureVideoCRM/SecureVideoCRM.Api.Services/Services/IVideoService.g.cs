using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecureVideoCRMNS.Api.Services
{
	public partial interface IVideoService
	{
		Task<CreateResponse<ApiVideoServerResponseModel>> Create(
			ApiVideoServerRequestModel model);

		Task<UpdateResponse<ApiVideoServerResponseModel>> Update(int id,
		                                                          ApiVideoServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiVideoServerResponseModel> Get(int id);

		Task<List<ApiVideoServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>87e48d0bc1773051c6d7e2571d961184</Hash>
</Codenesium>*/