using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IBadgeService
	{
		Task<CreateResponse<ApiBadgeServerResponseModel>> Create(
			ApiBadgeServerRequestModel model);

		Task<UpdateResponse<ApiBadgeServerResponseModel>> Update(int id,
		                                                          ApiBadgeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiBadgeServerResponseModel> Get(int id);

		Task<List<ApiBadgeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>07b034461baa2ec337ca9dc6f776cc7e</Hash>
</Codenesium>*/