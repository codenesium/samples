using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiAddressTypeModelMapper
	{
		ApiAddressTypeResponseModel MapRequestToResponse(
			int addressTypeID,
			ApiAddressTypeRequestModel request);

		ApiAddressTypeRequestModel MapResponseToRequest(
			ApiAddressTypeResponseModel response);

		JsonPatchDocument<ApiAddressTypeRequestModel> CreatePatch(ApiAddressTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>bb5edbb230ea6e7fd35dd429165a4e05</Hash>
</Codenesium>*/