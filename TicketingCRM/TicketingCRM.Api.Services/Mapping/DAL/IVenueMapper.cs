using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALVenueMapper
	{
		Venue MapModelToEntity(
			int id,
			ApiVenueServerRequestModel model);

		ApiVenueServerResponseModel MapEntityToModel(
			Venue item);

		List<ApiVenueServerResponseModel> MapEntityToModel(
			List<Venue> items);
	}
}

/*<Codenesium>
    <Hash>f64fb99eaa0516ada01f417f7997ea70</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/