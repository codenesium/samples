using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ILinkTypeService
	{
		Task<CreateResponse<ApiLinkTypeResponseModel>> Create(
			ApiLinkTypeRequestModel model);

		Task<UpdateResponse<ApiLinkTypeResponseModel>> Update(int id,
		                                                       ApiLinkTypeRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkTypeResponseModel> Get(int id);

		Task<List<ApiLinkTypeResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>285bef5262ec037243d7cdb004eb770f</Hash>
</Codenesium>*/