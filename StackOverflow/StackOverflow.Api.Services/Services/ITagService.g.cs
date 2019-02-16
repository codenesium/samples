using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ITagService
	{
		Task<CreateResponse<ApiTagServerResponseModel>> Create(
			ApiTagServerRequestModel model);

		Task<UpdateResponse<ApiTagServerResponseModel>> Update(int id,
		                                                        ApiTagServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTagServerResponseModel> Get(int id);

		Task<List<ApiTagServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>3a4526525a96d9d0ef5d7f2079622f86</Hash>
</Codenesium>*/