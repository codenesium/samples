using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ILinkTypeService
	{
		Task<CreateResponse<ApiLinkTypeServerResponseModel>> Create(
			ApiLinkTypeServerRequestModel model);

		Task<UpdateResponse<ApiLinkTypeServerResponseModel>> Update(int id,
		                                                             ApiLinkTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkTypeServerResponseModel> Get(int id);

		Task<List<ApiLinkTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a240077a586c3d79fded16bcd47fca67</Hash>
</Codenesium>*/