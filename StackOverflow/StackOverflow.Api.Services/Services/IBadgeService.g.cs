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

		Task<List<ApiBadgeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>804204b61c773968fd39fd0dda5cbc81</Hash>
</Codenesium>*/