using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestsNS.Api.Contracts
{
	public interface IApiTimestampCheckModelMapper
	{
		ApiTimestampCheckResponseModel MapRequestToResponse(
			int id,
			ApiTimestampCheckRequestModel request);

		ApiTimestampCheckRequestModel MapResponseToRequest(
			ApiTimestampCheckResponseModel response);

		JsonPatchDocument<ApiTimestampCheckRequestModel> CreatePatch(ApiTimestampCheckRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f5b45f1bd12661b094b795e2ec107b87</Hash>
</Codenesium>*/