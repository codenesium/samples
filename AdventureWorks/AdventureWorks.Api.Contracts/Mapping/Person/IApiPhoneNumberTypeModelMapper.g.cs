using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPhoneNumberTypeModelMapper
	{
		ApiPhoneNumberTypeResponseModel MapRequestToResponse(
			int phoneNumberTypeID,
			ApiPhoneNumberTypeRequestModel request);

		ApiPhoneNumberTypeRequestModel MapResponseToRequest(
			ApiPhoneNumberTypeResponseModel response);

		JsonPatchDocument<ApiPhoneNumberTypeRequestModel> CreatePatch(ApiPhoneNumberTypeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f422f876139b7a3a2cd34cdc8e7f2d33</Hash>
</Codenesium>*/