using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public interface IDALCountryMapper
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
    <Hash>777b5b1e14c33f33eee97b886bb855a7</Hash>
</Codenesium>*/