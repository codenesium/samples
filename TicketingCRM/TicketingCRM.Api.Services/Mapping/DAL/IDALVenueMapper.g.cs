using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALVenueMapper
	{
		Venue MapBOToEF(
			BOVenue bo);

		BOVenue MapEFToBO(
			Venue efVenue);

		List<BOVenue> MapEFToBO(
			List<Venue> records);
	}
}

/*<Codenesium>
    <Hash>8eb3af6b492e8a12be202ab47e6dee11</Hash>
</Codenesium>*/