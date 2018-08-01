using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLCityMapper
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
    <Hash>7007975e235af70c90ba197e1e2bbfa8</Hash>
</Codenesium>*/