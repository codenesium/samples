using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiPostLinksModelMapper
	{
		ApiPostLinksResponseModel MapRequestToResponse(
			int id,
			ApiPostLinksRequestModel request);

		ApiPostLinksRequestModel MapResponseToRequest(
			ApiPostLinksResponseModel response);

		JsonPatchDocument<ApiPostLinksRequestModel> CreatePatch(ApiPostLinksRequestModel model);
	}
}

/*<Codenesium>
    <Hash>cbc191ab47717f77bbcf20926f7b18da</Hash>
</Codenesium>*/