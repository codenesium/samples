using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Contracts
{
	public partial interface IApiTicketModelMapper
	{
		ApiTicketResponseModel MapRequestToResponse(
			int id,
			ApiTicketRequestModel request);

		ApiTicketRequestModel MapResponseToRequest(
			ApiTicketResponseModel response);

		JsonPatchDocument<ApiTicketRequestModel> CreatePatch(ApiTicketRequestModel model);
	}
}

/*<Codenesium>
    <Hash>82ea79994d2851ad664ca460affbf9d2</Hash>
</Codenesium>*/