using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostHistoryTypesService
	{
		Task<CreateResponse<ApiPostHistoryTypesResponseModel>> Create(
			ApiPostHistoryTypesRequestModel model);

		Task<UpdateResponse<ApiPostHistoryTypesResponseModel>> Update(int id,
		                                                               ApiPostHistoryTypesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostHistoryTypesResponseModel> Get(int id);

		Task<List<ApiPostHistoryTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a660b21b23c8d5843e5c988720359fcb</Hash>
</Codenesium>*/