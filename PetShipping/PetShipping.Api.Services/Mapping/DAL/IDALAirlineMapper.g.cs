using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public partial interface IDALAirlineMapper
	{
		Airline MapBOToEF(
			BOAirline bo);

		BOAirline MapEFToBO(
			Airline efAirline);

		List<BOAirline> MapEFToBO(
			List<Airline> records);
	}
}

/*<Codenesium>
    <Hash>fb28f6b1b9982add6fc1d26446a381cf</Hash>
</Codenesium>*/