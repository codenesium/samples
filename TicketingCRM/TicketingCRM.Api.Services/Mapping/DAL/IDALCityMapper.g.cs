using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALCityMapper
	{
		City MapBOToEF(
			BOCity bo);

		BOCity MapEFToBO(
			City efCity);

		List<BOCity> MapEFToBO(
			List<City> records);
	}
}

/*<Codenesium>
    <Hash>6d10606705afacb9c87a0dcd03503a50</Hash>
</Codenesium>*/