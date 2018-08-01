using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiAddressTypeModelMapper
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
    <Hash>bff129a85ce845d91ec51ec683898474</Hash>
</Codenesium>*/