using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLCityMapper
	{
		BOCity MapModelToBO(
			int id,
			ApiCityRequestModel model);

		ApiCityResponseModel MapBOToModel(
			BOCity boCity);

		List<ApiCityResponseModel> MapBOToModel(
			List<BOCity> items);
	}
}

/*<Codenesium>
    <Hash>0beec95d30d8e1400820eb533d88880c</Hash>
</Codenesium>*/