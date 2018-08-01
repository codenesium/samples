using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALVenueMapper
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
    <Hash>c65c7335dff7a20eab08410fa058f054</Hash>
</Codenesium>*/