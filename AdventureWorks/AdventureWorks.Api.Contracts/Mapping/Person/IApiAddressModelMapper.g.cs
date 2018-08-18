using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiAddressModelMapper
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
    <Hash>ea136004830cbcf35db66e50f410fcf0</Hash>
</Codenesium>*/