using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBadgesService
	{
		Task<CreateResponse<ApiBadgesServerResponseModel>> Create(
			ApiBadgesServerRequestModel model);

		Task<UpdateResponse<ApiBadgesServerResponseModel>> Update(int id,
		                                                           ApiBadgesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBadgesServerResponseModel> Get(int id);

		Task<List<ApiBadgesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiBadgesServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>95dd1a3ad2f7bb32922012c115d0b954</Hash>
</Codenesium>*/