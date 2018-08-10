using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostLinksService
	{
		Task<CreateResponse<ApiPostLinksResponseModel>> Create(
			ApiPostLinksRequestModel model);

		Task<UpdateResponse<ApiPostLinksResponseModel>> Update(int id,
		                                                        ApiPostLinksRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostLinksResponseModel> Get(int id);

		Task<List<ApiPostLinksResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>12bd58475ade350db3b24c6d4c42bf5f</Hash>
</Codenesium>*/