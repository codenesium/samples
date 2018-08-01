using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public interface IApiProvinceModelMapper
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
    <Hash>ef222ca801e7bbbfd0863bddfc51adf5</Hash>
</Codenesium>*/