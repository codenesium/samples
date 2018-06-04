using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
namespace PetShippingNS.Api.Services
{
	public interface IDALAirTransportMapper
	{
		AirTransport MapBOToEF(
			BOAirTransport bo);

		BOAirTransport MapEFToBO(
			AirTransport efAirTransport);

		List<BOAirTransport> MapEFToBO(
			List<AirTransport> records);
	}
}

/*<Codenesium>
    <Hash>f5f365d7f5afdb6becee40e8314231cc</Hash>
</Codenesium>*/