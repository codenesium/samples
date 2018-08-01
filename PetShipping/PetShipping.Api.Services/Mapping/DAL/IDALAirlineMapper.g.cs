using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
	public interface IDALAirlineMapper
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
    <Hash>9620e4b496f67de6046c4748ef42dc4b</Hash>
</Codenesium>*/