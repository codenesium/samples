using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
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
    <Hash>b42f4b0415de18efea153662d8980317</Hash>
</Codenesium>*/