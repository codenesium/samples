using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCityMapper
	{
		City MapModelToEntity(
			int id,
			ApiCityServerRequestModel model);

		ApiCityServerResponseModel MapEntityToModel(
			City item);

		List<ApiCityServerResponseModel> MapEntityToModel(
			List<City> items);
	}
}

/*<Codenesium>
    <Hash>a75bc5a3b05d853a36dc31d9637d5a3c</Hash>
</Codenesium>*/