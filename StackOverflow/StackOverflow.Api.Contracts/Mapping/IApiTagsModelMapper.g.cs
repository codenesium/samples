using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiTagsModelMapper
	{
		ApiTagsResponseModel MapRequestToResponse(
			int id,
			ApiTagsRequestModel request);

		ApiTagsRequestModel MapResponseToRequest(
			ApiTagsResponseModel response);

		JsonPatchDocument<ApiTagsRequestModel> CreatePatch(ApiTagsRequestModel model);
	}
}

/*<Codenesium>
    <Hash>febb4dc60ca089540706290355e8c439</Hash>
</Codenesium>*/