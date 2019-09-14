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

		Task<List<ApiLinkTypeServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostLinkServerResponseModel>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2aab86e9f5ef2894af670c9efaa318ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/