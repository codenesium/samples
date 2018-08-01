using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiAddressModelMapper
	{
		ApiAddressResponseModel MapRequestToResponse(
			int addressID,
			ApiAddressRequestModel request);

		ApiAddressRequestModel MapResponseToRequest(
			ApiAddressResponseModel response);

		JsonPatchDocument<ApiAddressRequestModel> CreatePatch(ApiAddressRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8f7de215e388ea5a22525436c50094ac</Hash>
</Codenesium>*/