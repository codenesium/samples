using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCityMapper
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
    <Hash>9ea1e5f4f8aed8af2d135424f7d1f363</Hash>
</Codenesium>*/