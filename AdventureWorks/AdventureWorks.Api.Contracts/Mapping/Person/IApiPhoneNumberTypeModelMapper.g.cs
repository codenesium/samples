using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPhoneNumberTypeModelMapper
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
    <Hash>fab169cedb983559ceed9c0dc0dabf06</Hash>
</Codenesium>*/