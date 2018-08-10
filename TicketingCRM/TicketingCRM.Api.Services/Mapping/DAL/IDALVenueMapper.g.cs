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
    <Hash>e0f7a54aea23c454bb2fda2604fdf1a3</Hash>
</Codenesium>*/