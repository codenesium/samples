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
    <Hash>d01227357968ca69b5b41ee7ce6f9918</Hash>
</Codenesium>*/