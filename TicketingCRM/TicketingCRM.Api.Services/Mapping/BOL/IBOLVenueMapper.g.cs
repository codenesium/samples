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
    <Hash>61a8024cfc05e9c72b96602841fb8e91</Hash>
</Codenesium>*/