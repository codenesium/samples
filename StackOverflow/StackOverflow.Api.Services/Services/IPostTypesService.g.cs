using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostTypesService
	{
		Task<CreateResponse<ApiPostTypesResponseModel>> Create(
			ApiPostTypesRequestModel model);

		Task<UpdateResponse<ApiPostTypesResponseModel>> Update(int id,
		                                                        ApiPostTypesRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostTypesResponseModel> Get(int id);

		Task<List<ApiPostTypesResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>7062a38839edbd3e74ee60ef00a5ef6c</Hash>
</Codenesium>*/