using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Services
{
	public partial interface IClaspService
	{
		Task<CreateResponse<ApiClaspServerResponseModel>> Create(
			ApiClaspServerRequestModel model);

		Task<UpdateResponse<ApiClaspServerResponseModel>> Update(int id,
		                                                          ApiClaspServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiClaspServerResponseModel> Get(int id);

		Task<List<ApiClaspServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>bb88e1e52aea923fc2e60e071b595058</Hash>
</Codenesium>*/