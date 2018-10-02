using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostTypeService
	{
		Task<CreateResponse<ApiPostTypeResponseModel>> Create(
			ApiPostTypeRequestModel model);

		Task<UpdateResponse<ApiPostTypeResponseModel>> Update(int id,
		                                                       ApiPostTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostTypeResponseModel> Get(int id);

		Task<List<ApiPostTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>126965d1855af2771a9c2f3c982549ea</Hash>
</Codenesium>*/