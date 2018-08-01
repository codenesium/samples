using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Contracts
{
	public interface IApiCustomerModelMapper
	{
		ApiCustomerResponseModel MapRequestToResponse(
			int customerID,
			ApiCustomerRequestModel request);

		ApiCustomerRequestModel MapResponseToRequest(
			ApiCustomerResponseModel response);

		JsonPatchDocument<ApiCustomerRequestModel> CreatePatch(ApiCustomerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>884efb11e6754ce7a14fbca4d6970e32</Hash>
</Codenesium>*/