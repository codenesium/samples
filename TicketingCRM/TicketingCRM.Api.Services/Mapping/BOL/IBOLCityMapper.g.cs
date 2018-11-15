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
			ApiCityServerRequestModel model);

		ApiCityServerResponseModel MapBOToModel(
			BOCity boCity);

		List<ApiCityServerResponseModel> MapBOToModel(
			List<BOCity> items);
	}
}

/*<Codenesium>
    <Hash>5575d51ae74cadba474c20ca41844a50</Hash>
</Codenesium>*/