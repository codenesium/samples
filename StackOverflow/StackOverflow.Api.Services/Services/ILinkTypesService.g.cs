using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public partial interface ILinkTypesService
	{
		Task<CreateResponse<ApiLinkTypesServerResponseModel>> Create(
			ApiLinkTypesServerRequestModel model);

		Task<UpdateResponse<ApiLinkTypesServerResponseModel>> Update(int id,
		                                                              ApiLinkTypesServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiLinkTypesServerResponseModel> Get(int id);

		Task<List<ApiLinkTypesServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiPostLinksServerResponseModel>> PostLinksByLinkTypeId(int linkTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>d23954ba114162f21c1d4cfc03b1b656</Hash>
</Codenesium>*/