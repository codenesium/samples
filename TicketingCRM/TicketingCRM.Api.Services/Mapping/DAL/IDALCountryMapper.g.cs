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
    <Hash>ecd40492cf94fee3a782d8cc587fc6e7</Hash>
</Codenesium>*/