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
    <Hash>5f08da907a723ee800deed5bcb2e148e</Hash>
</Codenesium>*/