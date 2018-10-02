using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public partial interface IApiIncludedColumnTestModelMapper
	{
		ApiIncludedColumnTestResponseModel MapRequestToResponse(
			int id,
			ApiIncludedColumnTestRequestModel request);

		ApiIncludedColumnTestRequestModel MapResponseToRequest(
			ApiIncludedColumnTestResponseModel response);

		JsonPatchDocument<ApiIncludedColumnTestRequestModel> CreatePatch(ApiIncludedColumnTestRequestModel model);
	}
}

/*<Codenesium>
    <Hash>08e265207130c51e938348506974e16b</Hash>
</Codenesium>*/