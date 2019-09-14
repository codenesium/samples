using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface IPostTypeService
	{
		Task<CreateResponse<ApiPostTypeServerResponseModel>> Create(
			ApiPostTypeServerRequestModel model);

		Task<UpdateResponse<ApiPostTypeServerResponseModel>> Update(int id,
		                                                             ApiPostTypeServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiPostTypeServerResponseModel> Get(int id);

		Task<List<ApiPostTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostServerResponseModel>> PostsByPostTypeId(int postTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>c1ce3e95ff1589335dccb1d28c1d0d70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/