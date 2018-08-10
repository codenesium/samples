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
			ApiVenueRequestModel model);

		ApiVenueResponseModel MapBOToModel(
			BOVenue boVenue);

		List<ApiVenueResponseModel> MapBOToModel(
			List<BOVenue> items);
	}
}

/*<Codenesium>
    <Hash>56c0f586306a3976a1c0284df4273b9e</Hash>
</Codenesium>*/