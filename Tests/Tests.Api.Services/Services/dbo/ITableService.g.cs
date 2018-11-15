using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
	public partial interface ITableService
	{
		Task<CreateResponse<ApiTableServerResponseModel>> Create(
			ApiTableServerRequestModel model);

		Task<UpdateResponse<ApiTableServerResponseModel>> Update(int id,
		                                                          ApiTableServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTableServerResponseModel> Get(int id);

		Task<List<ApiTableServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>e7e6e8706d1f9982d4a34817e8cde8d7</Hash>
</Codenesium>*/