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
    <Hash>ce5dcd61edd6fe5cc6c56262597f33b1</Hash>
</Codenesium>*/