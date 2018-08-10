using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public partial interface IApiPersonCreditCardModelMapper
	{
		ApiPersonCreditCardResponseModel MapRequestToResponse(
			int businessEntityID,
			ApiPersonCreditCardRequestModel request);

		ApiPersonCreditCardRequestModel MapResponseToRequest(
			ApiPersonCreditCardResponseModel response);

		JsonPatchDocument<ApiPersonCreditCardRequestModel> CreatePatch(ApiPersonCreditCardRequestModel model);
	}
}

/*<Codenesium>
    <Hash>aad8be06f38900f4ac3bb6b1e96dd430</Hash>
</Codenesium>*/