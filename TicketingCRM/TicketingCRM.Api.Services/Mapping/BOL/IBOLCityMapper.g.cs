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
    <Hash>dae318e37d2f165674678bb33861d85f</Hash>
</Codenesium>*/