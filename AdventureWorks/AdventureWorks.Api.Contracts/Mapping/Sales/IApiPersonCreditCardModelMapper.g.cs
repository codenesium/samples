using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiPersonCreditCardModelMapper
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
    <Hash>8484903ea6d4ba638b929234c07dd54e</Hash>
</Codenesium>*/