using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiProvinceModelMapper
	{
		ApiProvinceResponseModel MapRequestToResponse(
			int id,
			ApiProvinceRequestModel request);

		ApiProvinceRequestModel MapResponseToRequest(
			ApiProvinceResponseModel response);

		JsonPatchDocument<ApiProvinceRequestModel> CreatePatch(ApiProvinceRequestModel model);
	}
}

/*<Codenesium>
    <Hash>4ee63797eca0ee9d1fea9d07ebafd4e1</Hash>
</Codenesium>*/