using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IBOLVenueMapper
	{
		BOVenue MapModelToBO(
			int id,
			ApiVenueServerRequestModel model);

		ApiVenueServerResponseModel MapBOToModel(
			BOVenue boVenue);

		List<ApiVenueServerResponseModel> MapBOToModel(
			List<BOVenue> items);
	}
}

/*<Codenesium>
    <Hash>46d9c948b315600210e0f9ed6ec46e92</Hash>
</Codenesium>*/