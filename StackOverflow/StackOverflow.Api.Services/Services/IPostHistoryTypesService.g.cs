using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public interface IPostHistoryTypesService
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
    <Hash>6b04ee5286b76443873118b8b86e88a9</Hash>
</Codenesium>*/