using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiCityModelMapper
	{
		ApiCityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCityClientRequestModel request);

		ApiCityClientRequestModel MapClientResponseToRequest(
			ApiCityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>22b1018ebfd200425b06bd3804e42ee3</Hash>
</Codenesium>*/