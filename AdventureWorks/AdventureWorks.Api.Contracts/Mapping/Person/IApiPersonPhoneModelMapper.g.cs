using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPersonPhoneModelMapper
	{
		ApiPersonPhoneResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonPhoneRequestModel request);

		ApiPersonPhoneRequestModel MapResponseToRequest(
			ApiPersonPhoneResponseModel response);

		JsonPatchDocument<ApiPersonPhoneRequestModel> CreatePatch(ApiPersonPhoneRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a30f117a2a5ca05758eea0ffa93e06f0</Hash>
</Codenesium>*/