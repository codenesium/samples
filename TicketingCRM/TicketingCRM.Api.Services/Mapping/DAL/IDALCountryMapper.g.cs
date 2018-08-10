using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public partial interface IDALCountryMapper
	{
		Country MapBOToEF(
			BOCountry bo);

		BOCountry MapEFToBO(
			Country efCountry);

		List<BOCountry> MapEFToBO(
			List<Country> records);
	}
}

/*<Codenesium>
    <Hash>d391738889c367f413c587fc20756bf2</Hash>
</Codenesium>*/