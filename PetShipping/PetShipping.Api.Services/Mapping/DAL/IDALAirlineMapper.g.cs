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
    <Hash>20730611f073941b29588617d2048873</Hash>
</Codenesium>*/