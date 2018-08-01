using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiSaleModelMapper
	{
		ApiSaleResponseModel MapRequestToResponse(
			int id,
			ApiSaleRequestModel request);

		ApiSaleRequestModel MapResponseToRequest(
			ApiSaleResponseModel response);

		JsonPatchDocument<ApiSaleRequestModel> CreatePatch(ApiSaleRequestModel model);
	}
}

/*<Codenesium>
    <Hash>2919b147750f4f8e4aa35376ba3ade27</Hash>
</Codenesium>*/