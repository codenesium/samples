using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IBOLVenueMapper
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
    <Hash>dafac3497d40c4dc9ce7a4711eb3ee81</Hash>
</Codenesium>*/