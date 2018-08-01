using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPasswordModelMapper
	{
		ApiPasswordResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPasswordRequestModel request);

		ApiPasswordRequestModel MapResponseToRequest(
			ApiPasswordResponseModel response);

		JsonPatchDocument<ApiPasswordRequestModel> CreatePatch(ApiPasswordRequestModel model);
	}
}

/*<Codenesium>
    <Hash>ef2be1c285d1fa8c5ffcb5bfe2db4189</Hash>
</Codenesium>*/