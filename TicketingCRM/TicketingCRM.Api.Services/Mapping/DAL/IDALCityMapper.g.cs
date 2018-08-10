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
    <Hash>0941a01806455f8001f4defc2e582c24</Hash>
</Codenesium>*/