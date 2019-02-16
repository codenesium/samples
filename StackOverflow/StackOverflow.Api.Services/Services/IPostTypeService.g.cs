using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostTypeService
	{
		Task<CreateResponse<ApiPostTypeServerResponseModel>> Create(
			ApiPostTypeServerRequestModel model);

		Task<UpdateResponse<ApiPostTypeServerResponseModel>> Update(int id,
		                                                             ApiPostTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostTypeServerResponseModel> Get(int id);

		Task<List<ApiPostTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>ba6e12b19396956b50707f96410b09b8</Hash>
</Codenesium>*/